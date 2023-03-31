using System;
using System.Collections.Generic;

namespace Coder
{
    public partial class message
    {
        private string msg;
        private int total;
        private int code;
        private List<QuestionOrigin> data;

        public string Msg { get => msg; set => msg = value; }
        public int Total { get => total; set => total = value; }
        public int Code { get => code; set => code = value; }
        public List<QuestionOrigin> Data { get => data; set => data = value; }
    }
    /// <summary>
    /// 试题实例
    /// </summary>
    [Serializable]
    public partial class QuestionOrigin
    {
        // {
        // "msg":"操作成功",
        // "total":238,
        // "code":200,
        // "data":[
        // {"searchValue":null,
        // "createBy":null,
        // "createTime":null,
        // "updateBy":null,
        // "updateTime":null,
        // "remark":null,
        // "params":{},
        // "id":408145,
        // "articleId":null,
        // "type":1,
        // "title":"下列行星中，离地球最远且可供航海定位的是______。",
        // "titleImg":null,
        // "audioUrl":null,
        // "answerAudio":null,
        // "option":"{\"A\":\"金星\",\"B\":\"木星\",\"C\":\"火星\",\"D\":\"土星\"}",
        // "rightkey":"D",
        // "analysis":"天王星和海王星肉眼看不到，土星是离地球最远且可供航海定位的行星。",
        // "contentsId":0,
        // "fallible":0,
        // "errorProneFlag":0,
        // "audioUrl2":null,
        // "answerCount":0,
        // "errorCount":0,
        // "star":2,
        // "commentCount":61,
        // "articleCount":0,
        // "keyword":null,
        // "userId":0,
        // "errorRate":"0.3415",
        // "status":false,
        // "answer":null,
        // "subTitle":null,
        // "browseCount":null,
        // "likeCount":null,
        // "content":null,
        // "order":null,
        // "delete":false},
        // ]
        // }
        private string searchValue;
        private string createBy;
        private DateTime? createTime;
        private string updateBy;
        private DateTime? updateTime;
        private string remark;
        private string param;
        private int? id;
        private int? articleId;
        private int? type;
        private string title;
        private string titleImg;
        private string audioUrl;
        private string answerAudio;
        private string option;
        private string rightkey;
        private string analysis;
        private int? contentsId;
        private int? fallible;
        private int? errorProneFlag;
        private string audioUrl2;
        private int? answerCount;
        private int? errorCount;
        private int? star;
        private int? commentCount;
        private int? articleCount;
        private string keyword;
        private int? userId;
        private float? errorRate;
        private bool status;
        private int? answer;
        private string subTitle;
        private int? browseCount;
        private int? likeCount;
        private string content;
        private string order;
        private bool delete;



        public string SearchValue { get => searchValue; set => searchValue = value; }
        public string CreateBy { get => createBy; set => createBy = value; }
        public DateTime? CreateTime { get => createTime; set => createTime = value; }
        public string UpdateBy { get => updateBy; set => updateBy = value; }
        public DateTime? UpdateTime { get => updateTime; set => updateTime = value; }
        public string Remark { get => remark; set => remark = value; }
        public string Param { get => param; set => param = value; }
        public int? Id { get => id; set => id = value; }
        public int? ArticleId { get => articleId; set => articleId = value; }
        public int? Type { get => type; set => type = value; }
        public string Title { get => title; set => title = value; }
        public string TitleImg { get => titleImg; set => titleImg = value; }
        public string AudioUrl { get => audioUrl; set => audioUrl = value; }
        public string AnswerAudio { get => answerAudio; set => answerAudio = value; }
        public string Option { get => option; set => option = value; }
        public string Rightkey { get => rightkey; set => rightkey = value; }
        public string Analysis { get => analysis; set => analysis = value; }
        public int? ContentsId { get => contentsId; set => contentsId = value; }
        public int? Fallible { get => fallible; set => fallible = value; }
        public int? ErrorProneFlag { get => errorProneFlag; set => errorProneFlag = value; }
        public string AudioUrl2 { get => audioUrl2; set => audioUrl2 = value; }
        public int? AnswerCount { get => answerCount; set => answerCount = value; }
        public int? ErrorCount { get => errorCount; set => errorCount = value; }
        public int? Star { get => star; set => star = value; }
        public int? CommentCount { get => commentCount; set => commentCount = value; }
        public int? ArticleCount { get => articleCount; set => articleCount = value; }
        public string Keyword { get => keyword; set => keyword = value; }
        public int? UserId { get => userId; set => userId = value; }
        public float? ErrorRate { get => errorRate; set => errorRate = value; }
        public bool Status { get => status; set => status = value; }
        public int? Answer { get => answer; set => answer = value; }
        public string SubTitle { get => subTitle; set => subTitle = value; }
        public int? BrowseCount { get => browseCount; set => browseCount = value; }
        public int? LikeCount { get => likeCount; set => likeCount = value; }
        public string Content { get => content; set => content = value; }
        public string Order { get => order; set => order = value; }
        public bool Delete { get => delete; set => delete = value; }
    }

    public class answer {
        private string a;
        private string b;
        private string c;
        private string d;

        public string A { get => a; set => a = value; }
        public string B { get => b; set => b = value; }
        public string C { get => c; set => c = value; }
        public string D { get => d; set => d = value; }
    }
    public class Question
    {
        #region Model
        private int _questionid;
        private string _questiontitle;
        private string _answera;
        private string _answerb;
        private string _answerc;
        private string _answerd;
        private int _correctanswer;
        private string _explain;
        private string _imageaddress = "Default.jpg";
        private int _difficultyid;
        private int _userid;
        private DateTime _uploadtime ;
        private int _verifytimes = 5;
        private bool _isverified = true;
        private bool _isdelte = false;
        private int _issupported = 0;
        private int _isdesupported = 0;
        private int _papercodeid;
        private int? _textbookid;
        private int? _chapterid;
        private int? _pastexampaperid;
        private int? _pastexamquestionid;
        private string remark;
        /// <summary>
        /// 试题ID int identity(1,1) primary key
        /// </summary>
        public int QuestionId
        {
            set { _questionid = value; }
            get { return _questionid; }
        }
        /// <summary>
        /// 题目 text not null
        /// </summary>
        public string QuestionTitle
        {
            set { _questiontitle = value; }
            get { return _questiontitle; }
        }
        /// <summary>
        /// 选项A text  not null
        /// </summary>
        public string AnswerA
        {
            set { _answera = value; }
            get { return _answera; }
        }
        /// <summary>
        /// 选项B text  not null
        /// </summary>
        public string AnswerB
        {
            set { _answerb = value; }
            get { return _answerb; }
        }
        /// <summary>
        /// 选项C text  not null
        /// </summary>
        public string AnswerC
        {
            set { _answerc = value; }
            get { return _answerc; }
        }
        /// <summary>
        /// 选项D text  not null
        /// </summary>
        public string AnswerD
        {
            set { _answerd = value; }
            get { return _answerd; }
        }
        /// <summary>
        /// 参考答案 int  not null check(CorrectAnswer in(1,2,3,4))
        /// </summary>
        public int CorrectAnswer
        {
            set { _correctanswer = value; }
            get { return _correctanswer; }
        }
        /// <summary>
        /// 题目对应的图形(如果有) nvarchar(100) null
        /// </summary>
        public string ImageAddress
        {
            set { _imageaddress = value; }
            get { return _imageaddress; }
        }
        /// <summary>
        /// 外键,难度系数 int not null references Difficulty(DifficultyId)
        /// </summary>
        public int DifficultyId
        {
            set { _difficultyid = value; }
            get { return _difficultyid; }
        }
        /// <summary>
        /// 外键,上传此试题的用户 int not null references Users(UserId)
        /// </summary>
        public int UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 上传的时间 datetime not null default getdate()
        /// </summary>
        public DateTime UpLoadTime
        {
            set { _uploadtime = value; }
            get { return _uploadtime; }
        }
        /// <summary>
        /// 被审核的次数(三次以后进入终审) int not null default 0
        /// </summary>
        public int VerifyTimes
        {
            set { _verifytimes = value; }
            get { return _verifytimes; }
        }
        /// <summary>
        /// 是否审核通过标记,0为不通过,1为通过,只有通过审核以后,才将试题更新到审核后的状态,否则不更新 bit not null default 0
        /// </summary>
        public bool IsVerified
        {
            set { _isverified = value; }
            get { return _isverified; }
        }
        /// <summary>
        /// 软删除标记 bit not null default 0
        /// </summary>
        public bool IsDelte
        {
            set { _isdelte = value; }
            get { return _isdelte; }
        }
        /// <summary>
        /// 被赞次数 int not null default 0
        /// </summary>
        public int IsSupported
        {
            set { _issupported = value; }
            get { return _issupported; }
        }
        /// <summary>
        /// 被踩次数 int not null default 0
        /// </summary>
        public int IsDeSupported
        {
            set { _isdesupported = value; }
            get { return _isdesupported; }
        }
        /// <summary>
        /// 外键,题目所属的试卷代码ID int not null references PaperCodes(PaperCodeId)
        /// </summary>
        public int PaperCodeId
        {
            set { _papercodeid = value; }
            get { return _papercodeid; }
        }
        /// <summary>
        /// 外键,题目对应的教材(因为一个试卷代码可以有多本教材) int null references TextBook(TextBookId)
        /// </summary>
        public int? TextBookId
        {
            set { _textbookid = value; }
            get { return _textbookid; }
        }
        /// <summary>
        /// 试题所对应的章节 int null references Chapter(ChapterId)
        /// </summary>
        public int? ChapterId
        {
            set { _chapterid = value; }
            get { return _chapterid; }
        }
        /// <summary>
        /// 试题是否是历年真题,null表示不是真题 int null references PastExamPaper(PastExamPaperId)
        /// </summary>
        public int? PastExamPaperId
        {
            set { _pastexampaperid = value; }
            get { return _pastexampaperid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PastExamQuestionId
        {
            set { _pastexamquestionid = value; }
            get { return _pastexamquestionid; }
        }

        public string Explain { get => _explain; set => _explain = value; }
        public string Remark { get => remark; set => remark = value; }
        #endregion Model

    }
}



