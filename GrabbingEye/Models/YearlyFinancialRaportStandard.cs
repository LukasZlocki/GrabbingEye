using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabbingEye.Models
{
    class YearlyFinancialRaportStandard
    {
        [Display (Name="Name")]
        public string Name { get; set; }
        public int Year { get; set; }
        public int PrzychodyNettoZeSprzedazy { get; set; }
        public int ZyskDzialalnosciOperacyjnej { get; set; }
        public int ZyskBrutto { get; set; }
        public int ZyskNetto { get; set; }
        public int Amortyzacja { get; set; }
        public int Ebitda { get; set; }
        public int Aktywa { get; set; }
        public int KapitalWlasny { get; set; }
        public int LiczbaAkcji { get; set; }
        public int ZyskNaAkcje { get; set; }
        public int WartoscKsiegowaNaAkcje { get; set; }


        //SET
        public void SetDataForFinancialRaport(string data, int dataPackNb)
        {
            switch (dataPackNb)
            {
                case 0:
                    Name = data;
                    break;

                case 1:
                    Year = Convert.ToInt32(data);
                    break;

                case 2:
                    PrzychodyNettoZeSprzedazy = Convert.ToInt32(data);
                    break;

                case 3:
                    ZyskDzialalnosciOperacyjnej = Convert.ToInt32(data);
                    break;

                case 4:
                    ZyskBrutto = Convert.ToInt32(data);
                    break;

                case 5:
                    ZyskNetto = Convert.ToInt32(data);
                    break;

                case 6:
                    Amortyzacja = Convert.ToInt32(data);
                    break;

                case 7:
                    Ebitda = Convert.ToInt32(data);
                    break;

                case 8:
                    Aktywa = Convert.ToInt32(data);
                    break;

                case 9:
                    KapitalWlasny = Convert.ToInt32(data);
                    break;

                case 10:
                    LiczbaAkcji = Convert.ToInt32(data);
                    break;

                case 11:
                    ZyskNaAkcje = Convert.ToInt32(data);
                    break;

                case 12:
                    WartoscKsiegowaNaAkcje = Convert.ToInt32(data);
                    break;

            }


        }


    }
}
