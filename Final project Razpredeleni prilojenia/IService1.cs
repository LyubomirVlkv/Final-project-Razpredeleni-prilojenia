using ApplicationService1.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Final_project_Razpredeleni_prilojenia
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        [OperationContract]
       List<UserDTO> GetUser();

        [OperationContract]
        UserDTO GetUserById(int id);

        [OperationContract]
        string PostUser(UserDTO userDto);

        [OperationContract]
        string DeleteUser(int id);

        [OperationContract]
        List<PostDTO> GetPost();

        [OperationContract]
        PostDTO getPostById(int id);


        [OperationContract]
        string AddPost(PostDTO postDto);

        [OperationContract]
        string DeletePost(int id);

        [OperationContract]
        List<ThreadDTO> GetThread();

        [OperationContract]
        ThreadDTO getThreadById(int id);


        [OperationContract]
        string AddThread(ThreadDTO postDto);

        [OperationContract]
        string DeleteThread(int id);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "Final_project_Razpredeleni_prilojenia.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
