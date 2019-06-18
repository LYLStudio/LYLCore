using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LYLStudio.App.Web.Models
{
    [MetadataType(typeof(BasicInfoMetaData))]
    public partial class BasicInfoViewModel : AccountOpening.NaturalPerson.BasicInfoOfNaturalPerson
    {
        internal sealed class BasicInfoMetaData
        {
            [Required]
            [Display(Name ="身分證")]
            public string Id { get; set; }
        }
    }
}