using Common.Library.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Library.Resources;

namespace Common.Library.Utils
{
    /// <summary>
    /// 项目操作基础类
    /// </summary>
    public class ProjectUtils
    {
        /// <summary>
        /// 获取项目的具体信息，主要包含项目名，项目欢迎图片、项目默认图标和版本号
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ProjectInfo GetProjectInfo(ProjectType type)
        {
            ProjectInfo info = new ProjectInfo()
            {
                ProjectName = GetProjectName(type),
                icon = GetProjectIcon(type),
                LoginWelcomeLogo = GetProjectLogingImg(type),
                ProjectTitle = GetProjectName(type),
                Version = GetProjectVersion(type)
            };
            return info;
        }
        /// <summary>
        /// 获取版本号
        /// </summary>
        /// <returns></returns>
        public static string GetProjectVersion(ProjectType type)
        {
            switch (type)
            {
                case ProjectType.WG:
                    break;
                case ProjectType.Test:
                    break;
                default:
                    break;
            }
            return "";
        }
        /// <summary>
        /// 获取指定项目的名字
        /// </summary>
        /// <returns></returns>
        public static string GetProjectName(ProjectType project)
        {
            string name = "";
            switch (project)
            {
                case ProjectType.WG:
                    name = "舞钢市资源税调运卡防伪系统";
                    break;
                case ProjectType.Test:
                    name = "开发测试系统";
                    break;
                case ProjectType.Leave:
                    name = "研究院年休假管理系统";
                    break;
                case ProjectType.Train:
                    name = "12306抢票系统";
                    break;
                default:
                    name = "不支持的系统";
                    break;
            }
            return name;
        }

        /// <summary>
        /// 获取指定项目登录时的图像
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetProjectLogingImg(ProjectType project)
        {
            Bitmap bitmap;
            switch (project)
            {
                case ProjectType.WG:
                    bitmap = Resource.系统更新;
                    break;
                case ProjectType.Test:
                    bitmap = Resource.项目;
                    break;
                case ProjectType.Leave:
                    bitmap = Resource.环形加载001;
                    break;
                case ProjectType.Train:
                    bitmap = Resource._12306;
                    break;
                default:
                    bitmap = Resources.Resource.项目;
                    break;
            }

            return bitmap;
        }
        /// <summary>
        /// 根据项目获取图标
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public static Icon GetProjectIcon(ProjectType project)
        {
            Icon icon;
            switch (project)
            {
                case ProjectType.WG:
                    icon = Resources.Resource.舞钢税票系统;
                    break;
                case ProjectType.Test:
                    icon = Resources.Resource.系统设置;
                    break;
                default:
                    icon = Resources.Resource.默认系统;
                    break;
            }
            return icon;
        }
    }
}
