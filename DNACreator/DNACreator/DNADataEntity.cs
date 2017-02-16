using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNACreator
{
    public class DNADataEntity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 样品编号
        /// </summary>
        public string DataNum { get; set; }
        /// <summary>
        /// DNA档案号
        /// </summary>
        public string DnaNum { get; set; }
        /// <summary>
        /// 数据信息
        /// </summary>
        public string DnaData { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        public Dictionary<string,List<string>> DnaDataDetail { get; set; }  
    }
}
