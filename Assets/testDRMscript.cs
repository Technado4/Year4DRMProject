using UnityEngine;

public class testDRMscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public class Token 
    { 

        private string model; 

        private string identifier; 

        private int graphicID; 

 

        public Token(string mdl, string uuid, int gid) 

        { 

            model = mdl; 

            identifier = uuid; 

            graphicID = gid; 

        } 

 

        public string getModel() 

        { 

            return model; 

        } 

 

        public string getUUID() 

        { 

            return identifier; 

        } 

 

        public int getGraphicID() 

        { 

            return graphicID; 

        } 

 

    } 


}
