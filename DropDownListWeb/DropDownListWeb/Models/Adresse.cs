using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace DropDownListWeb.Models
{
    public class Postdistrikt
    {
        public Postdistrikt(int Postnr, string Bynavn)
        {
            this.Postnr = Postnr;
            this.Bynavn = Bynavn;
        }

        public int Postnr { get; set; }
        public string Bynavn { get; set; }

        public static IEnumerable<Postdistrikt> Set = new ObservableCollection<Postdistrikt>
        {
            new Postdistrikt(8000,"Aarhus"),
            new Postdistrikt(9000,"Aalborg"),
            new Postdistrikt(1000,"København")
        };
    }

    public class Adresse
    {
        public Adresse(string VejOgHusnr, Postdistrikt Postdistrikt)
        {
            this.VejOgHusnr = VejOgHusnr;
            this.Postdistrikt = Postdistrikt;
        }

        public Adresse()
        {
        }

        public string VejOgHusnr { get; set; }
        public Postdistrikt Postdistrikt { get; set; }
        public int? Postnr
        {
            get => Postdistrikt?.Postnr;
            set { Postdistrikt = Postdistrikt.Set.Where(p => p.Postnr == value).First(); }
        }

        public static IEnumerable<Adresse> Set = new ObservableCollection<Adresse>
        {
            new Adresse("Sønderhøj 30", Postdistrikt.Set.Where(p => p.Postnr==8000).First()),
            new Adresse("Reberbansgade 7", Postdistrikt.Set.Where(p => p.Postnr==9000).First()),
            new Adresse("Esplanaden 1", Postdistrikt.Set.Where(p => p.Postnr==1000).First())
        };
    }
}
