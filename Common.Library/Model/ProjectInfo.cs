using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library.Model
{
    public class ProjectInfo
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 窗体展示的名字
        /// </summary>
        public string ProjectTitle { get; set; }
        /// <summary>
        /// 当前版本号
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Logo登录时窗体展示的欢迎图像
        /// </summary>
        public Bitmap LoginWelcomeLogo { get; set; }
        /// <summary>
        /// 默认的图标
        /// </summary>
        public Icon icon { get; set; }

    }
}
