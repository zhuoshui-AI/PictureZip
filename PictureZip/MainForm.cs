using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ImageCompressor
{
    public partial class MainForm : Form
    {
        private string _sourceImagePath;
        private Image _originalImage;

        public MainForm()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            // 设置质量滑块范围和默认值
            qualityTrackBar.Minimum = 1;
            qualityTrackBar.Maximum = 100;
            qualityTrackBar.Value = 80;
            qualityLabel.Text = $"质量: {qualityTrackBar.Value}%";

            // 设置缩放比例选项
            scaleComboBox.Items.Add("100%");
            scaleComboBox.Items.Add("75%");
            scaleComboBox.Items.Add("50%");
            scaleComboBox.Items.Add("25%");
            scaleComboBox.Items.Add("自定义");
            scaleComboBox.SelectedIndex = 0;

            // 隐藏自定义尺寸输入框，仅在选择自定义时显示
            customWidthLabel.Visible = false;
            customWidthTextBox.Visible = false;
            customHeightLabel.Visible = false;
            customHeightTextBox.Visible = false;

            // 设置保存格式选项
            formatComboBox.Items.Add("JPEG (*.jpg)");
            formatComboBox.Items.Add("PNG (*.png)");
            formatComboBox.Items.Add("BMP (*.bmp)");
            formatComboBox.Items.Add("GIF (*.gif)");
            formatComboBox.SelectedIndex = 0;
        }

        private void selectImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "图片文件 | *.jpg;*.jpeg;*.png;*.bmp;*.gif|所有文件 (*.*)|*.*";
                openFileDialog.Title = "选择要压缩的图片";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 释放之前加载的图片资源
                        DisposeOriginalAndPreview();

                        _sourceImagePath = openFileDialog.FileName;
                        // 使用流读取，避免 Image.FromFile 锁定源文件
                        using (FileStream fs = new FileStream(_sourceImagePath, FileMode.Open, FileAccess.Read))
                        using (MemoryStream ms = new MemoryStream())
                        {
                            fs.CopyTo(ms);
                            ms.Position = 0;
                            _originalImage = Image.FromStream(ms);
                        }

                        // 显示图片信息
                        sourcePathTextBox.Text = _sourceImagePath;
                        originalSizeLabel.Text = $"原始尺寸: {_originalImage.Width} x {_originalImage.Height} 像素";

                        // 显示图片预览（按比例缩放以适应控件）
                        SetPreviewImageSafe(ResizeImageForPreview(_originalImage));

                        // 自动填充自定义尺寸为原始尺寸
                        customWidthTextBox.Text = _originalImage.Width.ToString();
                        customHeightTextBox.Text = _originalImage.Height.ToString();

                        // 启用压缩按钮
                        compressButton.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"无法加载图片: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private Image ResizeImageForPreview(Image originalImage)
        {
            if (originalImage == null || originalImage.Width == 0 || originalImage.Height == 0)
                return null;

            // 计算缩放比例以适应预览框
            int maxWidth = Math.Max(1, previewPictureBox.Width);
            int maxHeight = Math.Max(1, previewPictureBox.Height);

            float widthRatio = (float)maxWidth / originalImage.Width;
            float heightRatio = (float)maxHeight / originalImage.Height;
            float scaleRatio = Math.Min(widthRatio, heightRatio);

            // 如果图片本来就比预览框小，按原始尺寸显示
            if (scaleRatio > 1f)
                scaleRatio = 1f;

            int newWidth = Math.Max(1, (int)(originalImage.Width * scaleRatio));
            int newHeight = Math.Max(1, (int)(originalImage.Height * scaleRatio));

            return ResizeImage(originalImage, newWidth, newHeight);
        }

        private void scaleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 当选择"自定义"时显示尺寸输入框
            bool isCustom = scaleComboBox.SelectedItem != null && scaleComboBox.SelectedItem.ToString() == "自定义";
            customWidthLabel.Visible = isCustom;
            customWidthTextBox.Visible = isCustom;
            customHeightLabel.Visible = isCustom;
            customHeightTextBox.Visible = isCustom;

            // 如果有原始图片，根据选择的比例自动计算尺寸
            if (_originalImage != null && !isCustom && scaleComboBox.SelectedItem != null)
            {
                string selectedScale = scaleComboBox.SelectedItem.ToString();
                if (selectedScale.EndsWith("%"))
                {
                    if (float.TryParse(selectedScale.Replace("%", ""), out float percent))
                    {
                        float scale = percent / 100f;
                        customWidthTextBox.Text = ((int)(_originalImage.Width * scale)).ToString();
                        customHeightTextBox.Text = ((int)(_originalImage.Height * scale)).ToString();
                    }
                }
            }
        }

        private void qualityTrackBar_Scroll(object sender, EventArgs e)
        {
            qualityLabel.Text = $"质量: {qualityTrackBar.Value}%";
        }

        private void compressButton_Click(object sender, EventArgs e)
        {
            if (_originalImage == null)
            {
                MessageBox.Show("请先选择一张图片", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 验证尺寸输入
            if (!int.TryParse(customWidthTextBox.Text, out int newWidth) || newWidth <= 0)
            {
                MessageBox.Show("请输入有效的宽度", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(customHeightTextBox.Text, out int newHeight) || newHeight <= 0)
            {
                MessageBox.Show("请输入有效的高度", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (Image resizedImage = ResizeImage(_originalImage, newWidth, newHeight))
                {
                    // 选择保存路径
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        // 根据格式下拉索引映射扩展名和过滤器，避免脆弱的字符串拆分
                        string filter;
                        string extension;
                        switch (formatComboBox.SelectedIndex)
                        {
                            case 1:
                                filter = "PNG (*.png)|*.png";
                                extension = "png";
                                break;
                            case 2:
                                filter = "BMP (*.bmp)|*.bmp";
                                extension = "bmp";
                                break;
                            case 3:
                                filter = "GIF (*.gif)|*.gif";
                                extension = "gif";
                                break;
                            default:
                                filter = "JPEG (*.jpg)|*.jpg;*.jpeg";
                                extension = "jpg";
                                break;
                        }

                        saveFileDialog.Filter = filter + "|所有文件 (*.*)|*.*";

                        // 默认文件名
                        string originalFileName = string.IsNullOrEmpty(_sourceImagePath) ? "image" : Path.GetFileNameWithoutExtension(_sourceImagePath);
                        saveFileDialog.FileName = $"{originalFileName}_compressed.{extension}";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // 保存压缩后的图片
                            SaveCompressedImage(resizedImage, saveFileDialog.FileName, Math.Max(1, Math.Min(100, qualityTrackBar.Value)));

                            // 显示成功信息
                            long originalSize = 0;
                            try
                            {
                                originalSize = new FileInfo(_sourceImagePath).Length;
                            }
                            catch { originalSize = 0; }

                            long compressedSize = 0;
                            try
                            {
                                compressedSize = new FileInfo(saveFileDialog.FileName).Length;
                            }
                            catch { compressedSize = 0; }

                            float compressionRatio = (originalSize > 0) ? (1 - (float)compressedSize / originalSize) * 100f : 0f;

                            MessageBox.Show(
                                $"图片压缩成功!\n" +
                                $"原始大小: {FormatFileSize(originalSize)}\n" +
                                $"压缩后大小: {FormatFileSize(compressedSize)}\n" +
                                $"压缩率: {compressionRatio:F2}%",
                                "成功",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            // 显示压缩后的预览（使用流加载，避免锁文件）
                            try
                            {
                                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Open, FileAccess.Read))
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    fs.CopyTo(ms);
                                    ms.Position = 0;
                                    using (Image img = Image.FromStream(ms))
                                    {
                                        SetPreviewImageSafe(ResizeImageForPreview(img));
                                    }
                                }
                            }
                            catch
                            {
                                // 预览加载失败时忽略，不影响保存结果
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"压缩图片时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image ResizeImage(Image originalImage, int newWidth, int newHeight)
        {
            // 防御性检查
            if (originalImage == null)
                throw new ArgumentNullException(nameof(originalImage));
            newWidth = Math.Max(1, newWidth);
            newHeight = Math.Max(1, newHeight);

            // 判断是否含有透明通道
            bool hasAlpha = originalImage.PixelFormat == PixelFormat.Format32bppArgb
                            || originalImage.PixelFormat == PixelFormat.Format32bppPArgb
                            || originalImage.PixelFormat == PixelFormat.Format64bppArgb
                            || originalImage.PixelFormat == PixelFormat.Format64bppPArgb;

            PixelFormat targetFormat = hasAlpha ? PixelFormat.Format32bppArgb : PixelFormat.Format24bppRgb;
            Bitmap resizedBitmap = new Bitmap(newWidth, newHeight, targetFormat);

            using (Graphics graphics = Graphics.FromImage(resizedBitmap))
            {
                graphics.Clear(Color.Transparent);
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return resizedBitmap;
        }

        private void SaveCompressedImage(Image image, string filePath, int quality)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            string extension = Path.GetExtension(filePath)?.ToLowerInvariant() ?? ".jpg";
            ImageFormat format;
            string mime = "image/jpeg";

            switch (extension)
            {
                case ".png":
                    format = ImageFormat.Png;
                    mime = "image/png";
                    break;
                case ".bmp":
                    format = ImageFormat.Bmp;
                    mime = "image/bmp";
                    break;
                case ".gif":
                    format = ImageFormat.Gif;
                    mime = "image/gif";
                    break;
                case ".jpg":
                case ".jpeg":
                default:
                    format = ImageFormat.Jpeg;
                    mime = "image/jpeg";
                    break;
            }

            // 对于JPEG格式，设置压缩质量；其他格式直接保存
            if (format.Equals(ImageFormat.Jpeg))
            {
                ImageCodecInfo jpegCodec = GetEncoderInfo(mime);
                if (jpegCodec != null)
                {
                    using (EncoderParameters encoderParams = new EncoderParameters(1))
                    {
                        encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, (long)Math.Max(1, Math.Min(100, quality)));
                        image.Save(filePath, jpegCodec, encoderParams);
                    }
                }
                else
                {
                    image.Save(filePath, ImageFormat.Jpeg);
                }
            }
            else
            {
                image.Save(filePath, format);
            }
        }

        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (string.Equals(codec.MimeType, mimeType, StringComparison.OrdinalIgnoreCase))
                {
                    return codec;
                }
            }
            return null;
        }

        private string FormatFileSize(long bytes)
        {
            if (bytes <= 0)
                return "0 B";
            if (bytes < 1024)
                return $"{bytes} B";
            else if (bytes < 1048576)
                return $"{bytes / 1024.0:F2} KB";
            else
                return $"{bytes / 1048576.0:F2} MB";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeOriginalAndPreview();
        }

        private void DisposeOriginalAndPreview()
        {
            if (_originalImage != null)
            {
                try { _originalImage.Dispose(); } catch { }
                _originalImage = null;
            }

            if (previewPictureBox.Image != null)
            {
                try { previewPictureBox.Image.Dispose(); } catch { }
                previewPictureBox.Image = null;
            }
        }

        private void SetPreviewImageSafe(Image previewImage)
        {
            // 统一处理设置预览，先释放旧的
            if (previewPictureBox.Image != null)
            {
                try { previewPictureBox.Image.Dispose(); } catch { }
                previewPictureBox.Image = null;
            }

            previewPictureBox.Image = previewImage;
        }
    }
}
