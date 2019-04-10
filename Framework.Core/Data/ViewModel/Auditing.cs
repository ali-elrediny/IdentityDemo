using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Framework.Core.DataAnnotations;

using PagedList.Core;

namespace Framework.Core.Data.ViewModel
{
    public class AuditTypeViewModel //: PagingViewModel
    {
        //[Display(Name = "Field_ActionType_Id", ResourceType = typeof(AppMainResources))]
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredFieldMessage")]
        public Int32 Id { get; set; }

        //[Display(Name = "Field_ActionType_ApplicationTypeId", ResourceType = typeof(AppMainResources))]
        public Int32? ApplicationTypeId { get; set; }

        //[Display(Name = "Field_ActionType_NameAr", ResourceType = typeof(AppMainResources))]

        //[StringLength(50, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "StringLengthErrorMessage")]
        [ArabicTextOnly]
        public String NameAr { get; set; }

        //[Display(Name = "Field_ActionType_NameEn", ResourceType = typeof(AppMainResources))]

        //[StringLength(50, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "StringLengthErrorMessage")]
        [EnglishTextOnly]
        public String NameEn { get; set; }
    }



    public class AuditListViewModel// : PagingViewModel
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
        //[Display(Name = "Field_HistoryLog_Id", ResourceType = typeof(AppMainResources))]
        // [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredFieldMessage")]
        public Guid Id { get; set; }

      //  [Display(Name = "Field_HistoryLog_ItemId", ResourceType = typeof(AppMainResources))]
     //   [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredFieldMessage")]
        public Guid ItemId { get; set; }

      //  [Display(Name = "Field_HistoryLog_ActionTypeId", ResourceType = typeof(AppMainResources))]
      //  [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredFieldMessage")]
        public Int32 ActionTypeId { get; set; }

        [DisableScripts]
      //  [StringLength(256, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public String CreatedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DisableScripts]
     //   [StringLength(256, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public String UpdatedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedOn { get; set; }

     //   [Display(Name = "Field_HistoryLog_ItemJson", ResourceType = typeof(AppMainResources))]
     //   [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredFieldMessage")]
        public String ItemJson { get; set; }

     //   [Display(Name = "Field_HistoryLog_OldItemJson", ResourceType = typeof(AppMainResources))]
        public String OldItemJson { get; set; }

        public new StaticPagedList<AuditListItemViewModel> Items { get; set; }
    }

    public class AuditListItemViewModel
    {
        public Guid Id { get; set; }
        public int ActionTypeId { get; set; }
        public string ItemId { get; set; }
        public String ItemJson { get; set; }
        public String OldItemJson { get; set; }
    }

    public class HistoryLogViewModel
    {
     //   [Display(Name = "Field_HistoryLog_Id", ResourceType = typeof(AppMainResources))]
    //    [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredFieldMessage")]
        public Guid Id { get; set; }

     //   [Display(Name = "Field_HistoryLog_ItemId", ResourceType = typeof(AppMainResources))]
     //   [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredFieldMessage")]
        public Guid ItemId { get; set; }

     //   [Display(Name = "Field_HistoryLog_ActionTypeId", ResourceType = typeof(AppMainResources))]
     //   [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredFieldMessage")]
        public Int32 ActionTypeId { get; set; }

        [DisableScripts]
     //   [StringLength(256, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public String CreatedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DisableScripts]
     //   [StringLength(256, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public String UpdatedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedOn { get; set; }

     //   [Display(Name = "Field_HistoryLog_ItemJson", ResourceType = typeof(AppMainResources))]
     //   [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = "RequiredFieldMessage")]
        public String ItemJson { get; set; }

     //   [Display(Name = "Field_HistoryLog_OldItemJson", ResourceType = typeof(AppMainResources))]
        public String OldItemJson { get; set; }
    }
}
