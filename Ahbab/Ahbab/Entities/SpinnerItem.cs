using Newtonsoft.Json;
using SQLite;

namespace Asawer.Entities
{
    [Table("SpinnerItems")]
    public class SpinnerItem : DbObject
    {
        public SpinnerItem()
            :base()
        {
        }

        public SpinnerItem(int id, string itemDescriptionEn, string itemDescriptionAr)
            :base(id)
        {
            this.DescriptionEN = itemDescriptionEn;
            this.DescriptionAR = itemDescriptionAr;
        }

        public string DescriptionEN { get; set; }

        public string DescriptionAR { get; set; }

        [JsonIgnore]
        public string Type { get; set; }
    }
}
