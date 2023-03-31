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
using System.Threading.Tasks;

namespace Rename
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "E:\\img";
        }

        public List<Question> GetQuestions(DataTable dataTable)
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
        public DataSet GetList(string strWhere)
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
		public Question DataRowToModel(DataRow row)
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
        public bool updata(Question model)
        {
            bool issuccess = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Question set ");
            strSql.Append("QuestionTitle=@QuestionTitle,");
            strSql.Append("AnswerA=@AnswerA,");
            strSql.Append("AnswerB=@AnswerB,");
            strSql.Append("AnswerC=@AnswerC,");
            strSql.Append("AnswerD=@AnswerD,");
            strSql.Append("CorrectAnswer=@CorrectAnswer,");
            strSql.Append("ImageAddress=@ImageAddress,");
            strSql.Append("DifficultyId=@DifficultyId,");
            strSql.Append("UserId=@UserId,");
            strSql.Append("UpLoadTime=@UpLoadTime,");
            strSql.Append("VerifyTimes=@VerifyTimes,");
            strSql.Append("IsVerified=@IsVerified,");
            strSql.Append("IsDelte=@IsDelte,");
            strSql.Append("IsSupported=@IsSupported,");
            strSql.Append("IsDeSupported=@IsDeSupported,");
            strSql.Append("PaperCodeId=@PaperCodeId,");
            strSql.Append("TextBookId=@TextBookId,");
            strSql.Append("ChapterId=@ChapterId,");
            strSql.Append("PastExamPaperId=@PastExamPaperId,");
            strSql.Append("PastExamQuestionId=@PastExamQuestionId");
            strSql.Append(" where QuestionId=@QuestionId");
            SqlParameter[] parameters = {
                    new SqlParameter("@QuestionTitle", SqlDbType.Text),
                    new SqlParameter("@AnswerA", SqlDbType.Text),
                    new SqlParameter("@AnswerB", SqlDbType.Text),
                    new SqlParameter("@AnswerC", SqlDbType.Text),
                    new SqlParameter("@AnswerD", SqlDbType.Text),
                    new SqlParameter("@CorrectAnswer", SqlDbType.Int,4),
                    new SqlParameter("@ImageAddress", SqlDbType.NVarChar,100),
                    new SqlParameter("@DifficultyId", SqlDbType.Int,4),
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@UpLoadTime", SqlDbType.DateTime),
                    new SqlParameter("@VerifyTimes", SqlDbType.Int,4),
                    new SqlParameter("@IsVerified", SqlDbType.Bit,1),
                    new SqlParameter("@IsDelte", SqlDbType.Bit,1),
                    new SqlParameter("@IsSupported", SqlDbType.Int,4),
                    new SqlParameter("@IsDeSupported", SqlDbType.Int,4),
                    new SqlParameter("@PaperCodeId", SqlDbType.Int,4),
                    new SqlParameter("@TextBookId", SqlDbType.Int,4),
                    new SqlParameter("@ChapterId", SqlDbType.Int,4),
                    new SqlParameter("@PastExamPaperId", SqlDbType.Int,4),
                    new SqlParameter("@PastExamQuestionId", SqlDbType.Int,4),
                    new SqlParameter("@QuestionId", SqlDbType.Int,4)};
            parameters[0].Value = model.QuestionTitle;
            parameters[1].Value = model.AnswerA;
            parameters[2].Value = model.AnswerB;
            parameters[3].Value = model.AnswerC;
            parameters[4].Value = model.AnswerD;
            parameters[5].Value = model.CorrectAnswer;
            parameters[6].Value = model.ImageAddress;
            parameters[7].Value = model.DifficultyId;
            parameters[8].Value = model.UserId;
            parameters[9].Value = model.UpLoadTime;
            parameters[10].Value = model.VerifyTimes;
            parameters[11].Value = model.IsVerified;
            parameters[12].Value = model.IsDelte;
            parameters[13].Value = model.IsSupported;
            parameters[14].Value = model.IsDeSupported;
            parameters[15].Value = model.PaperCodeId;
            parameters[16].Value = model.TextBookId;
            parameters[17].Value = model.ChapterId;
            parameters[18].Value = model.PastExamPaperId;
            parameters[19].Value = model.PastExamQuestionId;
            parameters[20].Value = model.QuestionId;
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

        public bool rename(Question question, string path, out string newname)
        {
            bool issuccess = false;
            newname = Guid.NewGuid().ToString();
            return issuccess;
        }
    }
}
