namespace TiaViewer.Presentation.Wpf.Converters
{
    public class FullStringsFormatter : ConverterBase<string, string>
    {
        public string Format { get; set; }


        protected override string Convert(string source)
            => string.IsNullOrWhiteSpace(source) ? string.Empty : string.Format(Format, source);
    }
}