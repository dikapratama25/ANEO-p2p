using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Plexform.Base;
using Plexform.Audit;

namespace ANEO.DTO.P2P.Master.user_mstr
{
	#region USER_MSTR
	[Table("user_mstr")]
	//[Audited]
	public class USER_MSTR
	{
		[Key]
		[Required]
		public virtual long? UM_AUTO_NO { get; set; }
		[Key]
		[MaxLength(60), Required]
		public virtual string UM_USER_ID { get; set; }
		[Key]
		[MaxLength(3), Required]
		public virtual string UM_DELETED { get; set; }
		[Key]
		[MaxLength(60), Required]
		public virtual string UM_COY_ID { get; set; }

		public virtual byte[] UM_PASSWORD { get; set; }
		[MaxLength(300)]
		public virtual string UM_PASSWORD_NEW { get; set; }
		[MaxLength(300)]
		public virtual string UM_USER_NAME { get; set; }
		[MaxLength(30)]
		public virtual string UM_DEPT_ID { get; set; }
		[MaxLength(300)]
		public virtual string UM_EMAIL { get; set; }

		public virtual decimal? UM_APP_LIMIT { get; set; }

		public virtual decimal? UM_PO_APP_LIMIT { get; set; }
		[MaxLength(150)]
		public virtual string UM_DESIGNATION { get; set; }
		[MaxLength(150)]
		public virtual string UM_TEL_NO { get; set; }
		[MaxLength(150)]
		public virtual string UM_FAX_NO { get; set; }

		public virtual decimal? UM_USER_SUSPEND_IND { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? UM_PASSWORD_LAST_CHANGED { get; set; }
		[MaxLength(3)]
		public virtual string UM_NEW_PASSWORD_IND { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? UM_NEXT_EXPIRE_DT { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? UM_LAST_LOGIN_DT { get; set; }

		public virtual decimal? UM_QUESTION { get; set; }
		[MaxLength(450)]
		public virtual string UM_ANSWER { get; set; }
		[MaxLength(3)]
		public virtual string UM_MASS_APP { get; set; }
		[MaxLength(3), Required]
		public virtual string UM_STATUS { get; set; }
		[MaxLength(60)]
		public virtual string UM_MOD_BY { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? UM_MOD_DT { get; set; }
		[MaxLength(60)]
		public virtual string UM_ENT_BY { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? UM_ENT_DATE { get; set; }

		public virtual short? UM_RECORD_COUNT { get; set; }
		[MaxLength(3000)]
		public virtual string UM_EMAIL_CC { get; set; }

		public virtual decimal? UM_INVOICE_APP_LIMIT { get; set; }
		[MaxLength(3)]
		public virtual string UM_INVOICE_MASS_APP { get; set; }
		[MaxLength(3)]
		public virtual string UM_MRS_MASS_APP { get; set; }
		[MaxLength(3)]
		public virtual string UM_STK_TYPE_SPOT { get; set; }
		[MaxLength(3)]
		public virtual string UM_STK_TYPE_STOCK { get; set; }
		[MaxLength(3)]
		public virtual string UM_STK_TYPE_MRO { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? UM_POLICY_AGREE_DATE { get; set; }
		[MaxLength(3)]
		public virtual string UM_STAFF_CLAIM_EMAIL { get; set; }
	}
	#endregion
}
