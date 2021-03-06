#define TEST

using System.Linq;
using System.Runtime.Remoting.Messaging;
using AssemblyCSharp;
using GraphicLib.Data;
using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class StartUp : MonoBehaviour {

	// Use this for initialization
    private void Start()
    {

#if TEST
        var grapgicSet = new GraphicSet();
        var point = new Point(100, 10, 0);

        var line = new Line(new Point(20, 20, 0), new Point(30, 30, 0));

        var curve = new Curve(new List<Line>()
        {
            new Line(new Point(40,40,0), new Point(50,50,0)),
            new Line(new Point(50, 50, 0),new Point(20, 100, 0)),
            new Line(new Point(20, 100, 0),new Point(20, 111, 0)),
            new Line(new Point(20, 111, 0),new Point(50, 100, 0))
        });


        var trangular = new Trangular()
        {
            FirstLine = new Line(new Point(100, 200, 0), new Point(100, 300, 0) ),
            SecondLine = new Line(new Point(100, 300, 0), new Point(300, 300, 0)),
            ThridLine = new Line(new Point(300, 300, 0), new Point(100, 200, 0))
        };

        var face = new Face(new List<Trangular>()
        {
            new Trangular()
            {
                FirstLine = new Line(new Point(50, 0, 10), new Point(100, 0, 10) ),
            
                SecondLine = new Line(new Point(100, 0, 10), new Point(100, 100, 10)),
            
                ThridLine = new Line(new Point(100, 100, 10), new Point(0, 50, 10))
            },
            new Trangular()
            {
                FirstLine = new Line(new Point(0, 0, 10), new Point(100, 100, 10) ),
            
                SecondLine = new Line(new Point(100, 100, 10), new Point(0, 100, 10)),
            
                ThridLine = new Line(new Point(0, 100, 10), new Point(0, 0, 10))
                
            },
        });

        grapgicSet.GraphicObjects.Add(point);
        grapgicSet.GraphicObjects.Add(line);
        grapgicSet.GraphicObjects.Add(curve);
        grapgicSet.GraphicObjects.Add(trangular);
        grapgicSet.GraphicObjects.Add(face);

        var obj = grapgicSet.Draw();
        transform.position = grapgicSet.GetStartPoint() - new Vector3(0, 0, 10);


#else 

        string[] args = Environment.GetCommandLineArgs();

        if (args.Count() != 2)
        {
            UnityEngine.Application.Quit();
        }

        var filepath = args[1];

        var grapgicSet = XmlUtils<GraphicSet>.ImportFromXml(filepath);

        if (grapgicSet != null)
        {
            foreach (var graphicObject in grapgicSet.GraphicObjects)
            {
                try
                {
                    graphicObject.Draw();
                }
                catch (Exception)
                {
                    Debug.Log("Error");
                }

            }
        }
        else
        {
            UnityEngine.Application.Quit();
        }

#endif

    }


    // Update is called once per frame
	void Update () {
	
	}
}
