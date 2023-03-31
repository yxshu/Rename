using Coder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rename
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "E:\\img";
            int i = 0;
            //获取所有图片的名称
            foreach (string imagename in getImageAddressName())
            {
                if (String.IsNullOrEmpty(imagename.Trim())) continue;
                //生成一个新名称
                string newName = Guid.NewGuid().ToString() + ".jpg";
                try
                {
                    //第一步：修改数据库//第二步：修改文件名
                    updata(imagename, newName);
                    rename(path, imagename, newName);
                    Console.WriteLine("success:" + imagename + "-" + i);
                    i++;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("error:" + imagename + ex.Message);

                }
                //Thread.Sleep(2000);
            }
            Console.ReadLine();
        }

        public static List<string> getImageAddressName()
        {
            List<string> list = new List<string>();
            foreach (Question q in GetQuestions(GetList("").Tables[0]))
            {
                if (!list.Contains(q.ImageAddress))
                    list.Add(q.ImageAddress);
            }
            return list;
        }

        public static List<Question> GetQuestions(DataTable dataTable)
        {
            List<Question> list = new List<Question>();
            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(DataRowToModel(dr));
            }
            return list;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int QuestionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Question");
            strSql.Append(" where QuestionId=@QuestionId");
            SqlParameter[] parameters = {
                    new SqlParameter("@QuestionId", SqlDbType.Int,4)
            };
            parameters[0].Value = QuestionId;

            return SQLHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select QuestionId,QuestionTitle,AnswerA,AnswerB,AnswerC,AnswerD,CorrectAnswer,ImageAddress,DifficultyId,UserId,UpLoadTime,VerifyTimes,IsVerified,IsDelte,IsSupported,IsDeSupported,PaperCodeId,TextBookId,ChapterId,PastExamPaperId,PastExamQuestionId ");
            strSql.Append(" FROM Question ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SQLHelper.Query(strSql.ToString());
        }

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static Question DataRowToModel(DataRow row)
        {
            Question model = new Question();
            if (row != null)
            {
                if (row["QuestionId"] != null && row["QuestionId"].ToString() != "")
                {
                    model.QuestionId = int.Parse(row["QuestionId"].ToString());
                }
                if (row["QuestionTitle"] != null)
                {
                    model.QuestionTitle = row["QuestionTitle"].ToString();
                }
                if (row["AnswerA"] != null)
                {
                    model.AnswerA = row["AnswerA"].ToString();
                }
                if (row["AnswerB"] != null)
                {
                    model.AnswerB = row["AnswerB"].ToString();
                }
                if (row["AnswerC"] != null)
                {
                    model.AnswerC = row["AnswerC"].ToString();
                }
                if (row["AnswerD"] != null)
                {
                    model.AnswerD = row["AnswerD"].ToString();
                }
                if (row["CorrectAnswer"] != null && row["CorrectAnswer"].ToString() != "")
                {
                    model.CorrectAnswer = int.Parse(row["CorrectAnswer"].ToString());
                }
                if (row["ImageAddress"] != null)
                {
                    model.ImageAddress = row["ImageAddress"].ToString();
                }
                if (row["DifficultyId"] != null && row["DifficultyId"].ToString() != "")
                {
                    model.DifficultyId = int.Parse(row["DifficultyId"].ToString());
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["UpLoadTime"] != null && row["UpLoadTime"].ToString() != "")
                {
                    model.UpLoadTime = DateTime.Parse(row["UpLoadTime"].ToString());
                }
                if (row["VerifyTimes"] != null && row["VerifyTimes"].ToString() != "")
                {
                    model.VerifyTimes = int.Parse(row["VerifyTimes"].ToString());
                }
                if (row["IsVerified"] != null && row["IsVerified"].ToString() != "")
                {
                    if ((row["IsVerified"].ToString() == "1") || (row["IsVerified"].ToString().ToLower() == "true"))
                    {
                        model.IsVerified = true;
                    }
                    else
                    {
                        model.IsVerified = false;
                    }
                }
                if (row["IsDelte"] != null && row["IsDelte"].ToString() != "")
                {
                    if ((row["IsDelte"].ToString() == "1") || (row["IsDelte"].ToString().ToLower() == "true"))
                    {
                        model.IsDelte = true;
                    }
                    else
                    {
                        model.IsDelte = false;
                    }
                }
                if (row["IsSupported"] != null && row["IsSupported"].ToString() != "")
                {
                    model.IsSupported = int.Parse(row["IsSupported"].ToString());
                }
                if (row["IsDeSupported"] != null && row["IsDeSupported"].ToString() != "")
                {
                    model.IsDeSupported = int.Parse(row["IsDeSupported"].ToString());
                }
                if (row["PaperCodeId"] != null && row["PaperCodeId"].ToString() != "")
                {
                    model.PaperCodeId = int.Parse(row["PaperCodeId"].ToString());
                }
                if (row["TextBookId"] != null && row["TextBookId"].ToString() != "")
                {
                    model.TextBookId = int.Parse(row["TextBookId"].ToString());
                }
                if (row["ChapterId"] != null && row["ChapterId"].ToString() != "")
                {
                    model.ChapterId = int.Parse(row["ChapterId"].ToString());
                }
                if (row["PastExamPaperId"] != null && row["PastExamPaperId"].ToString() != "")
                {
                    model.PastExamPaperId = int.Parse(row["PastExamPaperId"].ToString());
                }
                if (row["PastExamQuestionId"] != null && row["PastExamQuestionId"].ToString() != "")
                {
                    model.PastExamQuestionId = int.Parse(row["PastExamQuestionId"].ToString());
                }
            }
            return model;
        }


        /// <summary>
        ///将数据更新回去 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        public static bool updata(string oldname, string newName)
        {
            bool issuccess = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Question set ");
            strSql.Append("ImageAddress=@newImageAddress");
            strSql.Append(" where ImageAddress=@oldImageAddress");
            SqlParameter[] parameters = {
                    new SqlParameter("@newImageAddress", SqlDbType.NVarChar,100),
                    new SqlParameter("@oldImageAddress", SqlDbType.NVarChar,100)};
            parameters[0].Value = newName;
            parameters[1].Value = oldname;
            int rows = SQLHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                issuccess = true;
            }
            else
            {
                issuccess = false;
            }
            return issuccess;
        }

        public static bool rename(string path, string oldname, string newname)
        {
            bool issuccess = false;
            File.Move(path + "\\" + oldname, path + "\\" + newname);
            return issuccess;
        }
    }
}
