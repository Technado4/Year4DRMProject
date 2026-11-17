using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class testDRMscript : MonoBehaviour
{
    private bool cooldown = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DRMTest());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DRMTest()
    {
        DRMCheck();
        yield return new WaitForSeconds(10);
        DRMCheck();
        yield return new WaitForSeconds(15);
        DRMCheck();
    }
    
    public bool DRMCheck()
    {
        if (cooldown)
        {
            Debug.Log("DRM on Cooldown!");
            return true;
        }
        
            
            cooldown = true;
            StartCoroutine(DRMCooldown());
            return compareIDs();
    }
    bool compareIDs()
    {
        string filename = "addresses.txt";
        if (File.Exists(filename))
        {
            StreamReader sr = File.OpenText(filename);
            string line = sr.ReadLine();
            int lineCount = 0;
            bool legal = true;
            Token token = new Token();
            while (line != null)
            {
                Debug.Log(line); // prints each line of the file
                if (lineCount == 0)
                {
                    if (!(token.getModel().Equals(line)))
                    {
                        legal = false;
                        Debug.Log("Model Different");
                        Debug.Log(line);
                    }
                }
                else if (lineCount == 1)
                {
                    if (!(token.getUUID().Equals(line)))
                    {
                        legal = false;
                        Debug.Log("UUID Different");
                        Debug.Log(line);
                    }
                }
                else
                {
                   if (token.getGraphicID() != int.Parse(line))
                    {
                        legal = false;
                        Debug.Log("Graphic Different");
                        Debug.Log(line);
                    }
                }
                lineCount++;
                line = sr.ReadLine();
            }

            Debug.Log(legal);
            return legal;
        }
        else
        {
            writeToFile();
            return true;
        }
        
    }

    void writeToFile()
    {
        string filename = "addresses.txt";
        StreamWriter sr = File.CreateText(filename);
        Token token = new Token();
        sr.WriteLine(token.getModel());
        sr.WriteLine(token.getUUID());
        sr.WriteLine(token.getGraphicID());
        sr.Close();
    }

    IEnumerator DRMCooldown()
    {
        yield return new WaitForSecondsRealtime(20);
        cooldown = false;
    }
    
    public class Token 
    { 

        private string model; 

        private string identifier; 

        private int graphicID; 

 

        public Token() 

        { 

            model = SystemInfo.deviceModel; 

            identifier = SystemInfo.deviceUniqueIdentifier; 

            graphicID = SystemInfo.graphicsDeviceID; 

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
