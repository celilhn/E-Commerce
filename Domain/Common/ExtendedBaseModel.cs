using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Domain.Constants.Constants;

namespace Domain.Common
{
    public class ExtendedBaseModel
    {
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "datetime"), DefaultValue("getdate()")]
        public DateTime InsertionDate { get; set; }
        [Column(TypeName = "datetime"), DefaultValue("getdate()")]
        public DateTime UpdateDate { get; set; }
        [Column(TypeName = "tinyint"), DefaultValue(1)]
        public StatusCodes Status { get; set; }
    }
}
