using DiplomaProject.OpenDotaAPI.APIModels;
using System.Text.RegularExpressions;

namespace DiplomaProject.OpenDotaAPI.PostProcces
{
    public class TotalsPost
    {
        public TotalsPost() { }

        public TotalsModel[] ChangeToNormal(TotalsModel[] models) {
            var result = new List<TotalsModel>();
            var model = models.Where(x=> x.field == "kills").First();
            model.field = "Вбивства";
            result.Add(model);
            model = models.Where(x => x.field == "deaths").First();
            model.field = "Смерті";
            result.Add(model);
            model = models.Where(x => x.field == "assists").First();
            model.field = "Підмоги";
            result.Add(model);
            model = models.Where(x => x.field == "last_hits").First();
            model.field = "Останні удари";
            result.Add(model);
            model = models.Where(x => x.field == "denies").First();
            model.field = "Добивань";
            result.Add(model);
            model = models.Where(x => x.field == "duration").First();
            model.field = "Час у грі";
            long t = Convert.ToInt64(model.count);
            TimeSpan time = TimeSpan.FromSeconds(t);
            model.count = time.ToString(@"dd\:hh\:mm\:ss");
            result.Add(model);
            model = models.Where(x => x.field == "level").First();
            model.field = "Рівні";
            result.Add(model);
            model = models.Where(x => x.field == "hero_damage").First();
            model.field = "Шкода по героям";
            result.Add(model);
            model = models.Where(x => x.field == "tower_damage").First();
            model.field = "Шкода по будівлям";
            result.Add(model);
            model = models.Where(x => x.field == "hero_healing").First();
            model.field = "Зцілення союзників";
            result.Add(model);
            foreach (var item in result)
            {
                if (item.field == "Час у грі")
                    continue;
                item.count = Reverse(Regex.Replace(Reverse(item.count), ".{3}", "$0 "));
                
            }
            return result.ToArray();
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
