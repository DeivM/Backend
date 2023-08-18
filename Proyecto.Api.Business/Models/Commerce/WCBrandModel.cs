using Newtonsoft.Json;

namespace Proyecto.Api.Business.Models.Commerce
{
    public class WCBrandModel
    {
        [JsonProperty("term_id")]
        public int TermId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("term_group")]
        public int TermGroup { get; set; }

        [JsonProperty("term_taxonomy_id")]
        public int TermTaxonomyId { get; set; }

        [JsonProperty("taxonomy")]
        public string Taxonomy { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; } = "";

        [JsonProperty("parent")]
        public int Parent { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("filter")]
        public string Filter { get; set; }

        [JsonProperty("brand_image")]
        public bool BrandImage { get; set; }

        [JsonProperty("brand_banner")]
        public bool BrandBanner { get; set; }
    }
}
