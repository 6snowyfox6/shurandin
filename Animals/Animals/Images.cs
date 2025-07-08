using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class ConservationStatus
    {
        public int id { get; set; }
        public object place_id { get; set; }
        public int? source_id { get; set; }
        public object user_id { get; set; }
        public string authority { get; set; }
        public string status { get; set; }
        public string status_name { get; set; }
        public string geoprivacy { get; set; }
        public int iucn { get; set; }
    }

    public class DefaultPhoto
    {
        public int id { get; set; }
        public string license_code { get; set; }
        public string attribution { get; set; }
        public string url { get; set; }
        public OriginalDimensions original_dimensions { get; set; }
        public List<object> flags { get; set; }
        public string attribution_name { get; set; }
        public string square_url { get; set; }
        public string medium_url { get; set; }
    }

    public class FlagCounts
    {
        public int resolved { get; set; }
        public int unresolved { get; set; }
    }

    public class OriginalDimensions
    {
        public int height { get; set; }
        public int width { get; set; }
    }

    public class Result
    {
        public int id { get; set; }
        public string rank { get; set; }
        public int rank_level { get; set; }
        public int iconic_taxon_id { get; set; }
        public List<int> ancestor_ids { get; set; }
        public bool is_active { get; set; }
        public string name { get; set; }
        public int parent_id { get; set; }
        public string ancestry { get; set; }
        public bool extinct { get; set; }
        public DefaultPhoto default_photo { get; set; }
        public int taxon_changes_count { get; set; }
        public int taxon_schemes_count { get; set; }
        public int observations_count { get; set; }
        public FlagCounts flag_counts { get; set; }
        public object current_synonymous_taxon_ids { get; set; }
        public int? atlas_id { get; set; }
        public int? complete_species_count { get; set; }
        public string wikipedia_url { get; set; }
        public string complete_rank { get; set; }
        public string matched_term { get; set; }
        public string iconic_taxon_name { get; set; }
        public string preferred_common_name { get; set; }
        public ConservationStatus conservation_status { get; set; }
    }

    public class Root
    {
        public int total_results { get; set; }
        public int page { get; set; }
        public int per_page { get; set; }
        public List<Result> results { get; set; }
    }
}
