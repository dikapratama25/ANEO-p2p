using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;

namespace ANEO.Base.P2P.Master.Map.analysis_code
{
	#region ANALYSIS_CODE
	[Abp.AutoMapper.AutoMapTo(typeof(ANEO.DTO.P2P.Master.analysis_code.ANALYSIS_CODE))]
	public class MapANALYSIS_CODE : BaseMapId
	{
		[JsonProperty("ac_b_coy_id")]
		[MaxLength(60), Required]
		[Grid(IsVisible = false)]
		public virtual string AC_B_COY_ID { get; set; }
		[JsonProperty("ac_analysis_code")]
		[MaxLength(300), Required]
		[Grid(Width = 150)]
		public virtual string AC_ANALYSIS_CODE { get; set; }
		[JsonProperty("ac_analysis_code_desc")]
		[MaxLength(300), Required]
		[Grid(Width = 150)]
		public virtual string AC_ANALYSIS_CODE_DESC { get; set; }
		[JsonProperty("ac_dept_code")]
		[MaxLength(60), Required]
		[Grid(IsVisible = false)]
		public virtual string AC_DEPT_CODE { get; set; }
		[JsonProperty("ac_lookup_code")]
		[MaxLength(300)]
		[Grid(IsVisible = false)]
		public virtual string AC_LOOKUP_CODE { get; set; }
		[JsonProperty("ac_budget_checking")]
		[MaxLength(3)]
		[Grid(IsVisible = false)]
		public virtual string AC_BUDGET_CHECKING { get; set; }
		[JsonProperty("ac_budget_stop")]
		[MaxLength(3)]
		[Grid(IsVisible = false)]
		public virtual string AC_BUDGET_STOP { get; set; }
		[JsonProperty("ac_prohibit_posting")]
		[MaxLength(3)]
		[Grid(IsVisible = false)]
		public virtual string AC_PROHIBIT_POSTING { get; set; }
		[JsonProperty("ac_budget_navigation_method")]
		[MaxLength(60)]
		[Grid(IsVisible = false)]
		public virtual string AC_BUDGET_NAVIGATION_METHOD { get; set; }
		[JsonProperty("ac_combined_budget_check")]
		[MaxLength(3)]
		[Grid(IsVisible = false)]
		public virtual string AC_COMBINED_BUDGET_CHECK { get; set; }
		[JsonProperty("ac_data_access_group")]
		[MaxLength(300)]
		[Grid(IsVisible = false)]
		public virtual string AC_DATA_ACCESS_GROUP { get; set; }
		[JsonProperty("ac_status")]
		[MaxLength(3)]
		[Grid(IsVisible = false)]
		public virtual string AC_STATUS { get; set; }
		[JsonProperty("ac_analysis_dimension")]
		[MaxLength(60)]
		[Grid(IsVisible = false)]
		public virtual string AC_ANALYSIS_DIMENSION { get; set; }
		[JsonProperty("ac_update_count")]
		[Grid(IsVisible = false)]
		public virtual int? AC_UPDATE_COUNT { get; set; }
		[JsonProperty("ac_last_updated_by")]
		[MaxLength(60)]
		[Grid(IsVisible = false)]
		public virtual string AC_LAST_UPDATED_BY { get; set; }
		[JsonProperty("ac_last_update_date")]
		[Grid(IsVisible = false)]
		public virtual System.DateTime? AC_LAST_UPDATE_DATE { get; set; }
	}
	#endregion
}