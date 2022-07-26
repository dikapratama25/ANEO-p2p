/*----- RFQDTO.cs -----*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Plexform.Base;
using Plexform.Audit;


namespace ANEO.DTO.P2P.Master.rfq_mstr
{
	#region RFQ_MSTR
	[Table("rfq_mstr")]
	//[Audited]
	public class RFQ_MSTR
	{
		[Key]
		[Required]
		public virtual long? RM_RFQ_ID { get; set; }
		[MaxLength(60)]
		public virtual string RM_Coy_ID { get; set; }
		[MaxLength(120)]
		public virtual string RM_RFQ_No { get; set; }
		[MaxLength(300)]
		public virtual string RM_RFQ_Name { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? RM_Expiry_Date { get; set; }
		[MaxLength(3)]
		public virtual string RM_Status { get; set; }
		[MaxLength(3000)]
		public virtual string RM_Remark { get; set; }
		[MaxLength(150), Required]
		public virtual string RM_Created_By { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? RM_Created_On { get; set; }
		[MaxLength(30)]
		public virtual string RM_Currency_Code { get; set; }
		[MaxLength(30)]
		public virtual string RM_Payment_Term { get; set; }
		[MaxLength(30)]
		public virtual string RM_Payment_Type { get; set; }
		[MaxLength(60)]
		public virtual string RM_Shipment_Term { get; set; }
		[MaxLength(60)]
		public virtual string RM_Shipment_Mode { get; set; }
		[MaxLength(150)]
		public virtual string RM_Prefix { get; set; }
		[MaxLength(3)]
		public virtual string RM_B_Display_Status { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? RM_Reqd_Quote_Validity { get; set; }
		[MaxLength(150)]
		public virtual string RM_Contact_Person { get; set; }
		[MaxLength(150)]
		public virtual string RM_Contact_Number { get; set; }
		[MaxLength(180)]
		public virtual string RM_Email { get; set; }
		[MaxLength(3)]
		public virtual string RM_RFQ_OPTION { get; set; }

		public virtual int? RM_VEN_DISTR_LIST_INDEX { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? RM_Submission_Date { get; set; }
		[MaxLength(60)]
		public virtual string RM_DEL_CODE { get; set; }
	}
	#endregion
}