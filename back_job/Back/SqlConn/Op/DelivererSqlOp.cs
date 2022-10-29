using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Back.ObjClass;

namespace Back.SqlConn.Op
{
    public class DelivererSqlOp:Delivererfa
    {
        public Deliverer GetOneDeliverer(string Dno)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from deliverer where Dno='" + Dno + "';";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Deliverer deliverer = new Deliverer(reader.GetString(0),reader.GetString(2),reader.GetString(1),reader.GetString(4),reader.GetString(3),reader.GetString(6),reader.GetDecimal(5));
            conn.Close();
            return deliverer;
        }
        public Dictionary<string, Deliverer> GetAllDeliverer()
        {
            Dictionary<string, Deliverer> deliverers = new Dictionary<string, Deliverer>();
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from deliverer;";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Deliverer deliverer = new Deliverer(reader.GetString(0), reader.GetString(2), reader.GetString(1), reader.GetString(4), reader.GetString(3), reader.GetString(6), reader.GetDecimal(5));
                deliverers.Add(reader.GetString(0), deliverer);
            }
            conn.Close();
            return deliverers;
        }
        public void InsertOneDeliverer(Deliverer deliverer)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText="insert into deliverer values('"+deliverer.GetPno()+"','"+ deliverer.GetPassword()+"','"+deliverer.GetName() + "','" + deliverer.GetSex() + "','" + deliverer.GetPhoneNumber() + "'," + deliverer.GetMoney() + ",'" + deliverer.GetState() + "');";
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateOneDeliverer(Deliverer deliverer)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "update deliverer set Dpass = '" + deliverer.GetPassword() + "',Dname = '" + deliverer.GetName() + "',Dsex='" + deliverer.GetSex()+"',Dstate='"+deliverer.GetState() + "',Dtel='" + deliverer.GetPhoneNumber() + "',Dmoney=" + deliverer.GetMoney().ToString() + " where Dno='"+deliverer.GetPno()+"';";
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteOneDeliverer(Deliverer deliverer)
        {
            SqlConnection conn = new ConnectSQL().Connect();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Delete from deliverer where Dno='" + deliverer.GetPno() + "';";
            Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void Main()
        {
            Delivererfa delivererfa = new DelivererSqlOp();
            Deliverer deliverer = new Deliverer("003","玛琪玛","123","65431","F", "正在配送", 0);
            //Deliverer deliverer = new Deliverer("003", "玛琪玛", "123", "65431", "F", "正在配送", 0);
            //delivererfa.InsertOneDeliverer(deliverer);
            //Deliverer deliverer = delivererfa.GetOneDeliverer("003");
            //delivererfa.DeleteOneDeliverer(deliverer);
            delivererfa.InsertOneDeliverer(deliverer);
            Dictionary<string, Deliverer> deliverers = delivererfa.GetAllDeliverer();
            foreach (Deliverer deliverer1 in deliverers.Values)
            {
                Console.WriteLine(deliverer1.toString());
            }
        }
    }
}
