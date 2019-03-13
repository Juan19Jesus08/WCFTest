using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService1;

namespace ServicioWTF
{

    [ServiceContract]
    public interface IService1
    {



      

       
        

        [OperationContract]
        [WebInvoke(UriTemplate = "GetAllStudents", Method = "GET",
      BodyStyle = WebMessageBodyStyle.Wrapped,
      ResponseFormat = WebMessageFormat.Json,
      RequestFormat = WebMessageFormat.Json)]
        [return: MessageParameter(Name = "alumnos")]
        List<WcfService1.Alumno> GetAllStudents();


        [OperationContract]
        [WebInvoke(UriTemplate = "FindStudent/{id}", Method = "GET",
       BodyStyle = WebMessageBodyStyle.Wrapped,
       ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json)]
        [return: MessageParameter(Name = "alumno")]
        List<WcfService1.Alumno> FindStudent(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetAllBachelors", Method = "GET",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json)]
        [return :MessageParameter(Name = "carrera")]
        List<WcfService1.Carrera> GetAllBachelors();
    }

}
