namespace TiaViewer.Presentation.Wpf.Converters
{
    /// <summary>
    /// Formatter for not empty string
    /// </summary>
    /// <remarks>Will be format only if source sting is not empty or has symbols</remarks>
    public class NotEmptyStringsFormatter : ConverterBase<string, string>
    {
        /// <summary>
        /// Format
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>Formatted string</returns>
        protected override string Convert(string source)
            => string.IsNullOrWhiteSpace(source) ? string.Empty : string.Format(Format, source);
    }
}