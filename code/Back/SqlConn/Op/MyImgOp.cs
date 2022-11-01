using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.SqlConn.Op
{
    public class MyImgOp
    {
        /// <summary>
        /// 将图片能转化为二进制流
        /// </summary>
        /// <param name="img_path"></param>
        /// <returns>byte[]二进制数组</returns>
        public byte[] TurnImgToByte(string img_path)
        {
            FileStream fileStream = new FileStream(img_path, FileMode.Open, FileAccess.Read);
            int byteLength = (int)fileStream.Length;
            byte[] fileBytes = new byte[byteLength];
            fileStream.Read(fileBytes, 0, byteLength);
            fileStream.Close();
            //Console.WriteLine(fileBytes);
            return fileBytes;
        }
        //public static void Main()
        //{
        //    MyImgOp op = new MyImgOp();
        //    byte[] img = op.TurnImgToByte(@"D:\myStudy\大三啊啊要毕业了\数据库\BIG_WORK\img\kitty.jpg");
        //}
    }
}
