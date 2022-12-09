using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;



namespace CSI_Project.Models
{
    public class DbNameModel
    {
        public List<DbName> dbNames { get; set; }

        public int CurrentIndex { get; set; }

        public int PageCount { get; set;}
    }
    public class DbName
    {
        [Key]
        public int dataset_id { get; set; }

        public string dataset_name { get; set; }

        public string age_of_data { get; set; }

        public string frequency_Internally { get; set; }

        public string status { get; set; }

        public string source { get; set; }

        public string delivery_method { get; set; }

        public DateTime delivery_date { get; set; }

        public string frequency_from_OS { get; set; }

        public string next_Update { get; set; }

        public string used_by { get; set; }

        public string supply_format { get; set; }

        public string status_ID { get; set; }
    }
}