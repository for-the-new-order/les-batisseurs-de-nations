using AntDesign;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesBatisseursDeNations
{
    public class UserOptions
    {
        public SiderTheme SiderTheme => SiderTheme.Dark;
        public MenuTheme MenuTheme => MenuTheme.Dark;
        public CultureInfo Culture { get; } = new CultureInfo("fr-CA");
    }
}
