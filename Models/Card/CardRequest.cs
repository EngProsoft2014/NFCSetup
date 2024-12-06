using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCSetup.Mode_s.Card
{
    public class CardRequest
    {
        public string CardName { get; set; } = default!;
        public string? Cardlayout { get; set; } = default!;
        public byte[]? ImgFileProfile { get; set; }
        public string? ExtensionProfile { get; set; } = string.Empty;
        public byte[]? ImgFileCover { get; set; }
        public string? ExtensionCover { get; set; } = string.Empty;
        public string? PersonName { get; set; } = default!;
        public string? PersonNikeName { get; set; } = default!;
        public string? location { get; set; } = default!;
        public string? JobTitle { get; set; } = default!;
        public string? Bio { get; set; } = default!;
        public string? CardTheme { get; set; } = default!;
        public string? LinkColor { get; set; } = default!;
        public string? FontStyle { get; set; } = default!;
    }
}
