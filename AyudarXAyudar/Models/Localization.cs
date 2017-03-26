using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AyudarXAyudar.Models
{
    public sealed class Localizations
    {
        public List<Localization> SupportedLocalizations { get; } = new List<Localization>
        {
            new Localization {Name = "English", ImageUri = "~/Content/Images/usFlag.png"}
            , new Localization {Name = "Español", ImageUri = "~/Content/Images/mexicanFlag.png"}
        };

        public struct Localization
        {
            public string Name { get; set; }
            public string ImageUri { get; set; }
        }
    }
}