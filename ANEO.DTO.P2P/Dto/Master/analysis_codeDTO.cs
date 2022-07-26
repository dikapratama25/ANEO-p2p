using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Plexform.Base;
using Plexform.Audit;

namespace ANEO.DTO.P2P.Master.analysis_code
{
	#region ANALYSIS_CODE
	[Table("analysis_code")]
	//[Audited]
	public class ANALYSIS_CODE
	{
		[Key]
		[MaxLength(60), Required]
		public virtual string AC_B_COY_ID { get; set; }
		[Key]
		[MaxLength(300), Required]
		public virtual string AC_ANALYSIS_CODE { get; set; }
		[Key]
		[MaxLength(300), Required]
		public virtual string AC_ANALYSIS_CODE_DESC { get; set; }
		[Key]
		[MaxLength(60), Required]
		public virtual string AC_DEPT_CODE { get; set; }
		[MaxLength(300)]
		public virtual string AC_LOOKUP_CODE { get; set; }
		[MaxLength(3)]
		public virtual string AC_BUDGET_CHECKING { get; set; }
		[MaxLength(3)]
		public virtual string AC_BUDGET_STOP { get; set; }
		[MaxLength(3)]
		public virtual string AC_PROHIBIT_POSTING { get; set; }
		[MaxLength(60)]
		public virtual string AC_BUDGET_NAVIGATION_METHOD { get; set; }
		[MaxLength(3)]
		public virtual string AC_COMBINED_BUDGET_CHECK { get; set; }
		[MaxLength(300)]
		public virtual string AC_DATA_ACCESS_GROUP { get; set; }
		[MaxLength(3)]
		public virtual string AC_STATUS { get; set; }
		[MaxLength(60)]
		public virtual string AC_ANALYSIS_DIMENSION { get; set; }

		public virtual int? AC_UPDATE_COUNT { get; set; }
		[MaxLength(60)]
		public virtual string AC_LAST_UPDATED_BY { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? AC_LAST_UPDATE_DATE { get; set; }
	}
	#endregion
}