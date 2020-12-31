using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the linked list is made up of wind objects that include the
//associated data of a wind vector:

unsafe public class node 
{
    //constructor for the node
    public node()
    {
        next = null;
        prev = null;

        //create an object of the windInfo class
        info = new windInfo(0, 0);

    }

    public node(windInfo a_info)
    {
        next = null;
        prev = null;

        info = a_info;
    }

    //this class "node" HAS A object of the "winfInfo" class as a data member (seen below) of the node.
    //As in, each node is an object of the windInfo class (plus more). Using the object of the windInfo class we
    //have declared below, we will call windInfo's display function that displays the speed and direction.
    //The data in the windInfo's display function is private, so we need this function to act as a wrapper
    //function so we can access that data.
    public void display()
    {
        info.display();

    }

    //maybe need copy constructor?

    //so we can return a pointer to actual the next and previous objects:    
    public node go_next()
    {
        return next;
    }


    public void connect_next(node connection)
    {
        next = connection;
    }

 

    //add a windInfo object to the list
    //public void add_wind(windInfo a_wind);

    private node next;
    //might not need prev
    private node prev;

    //objects of the windInfo class is the data for this list
    private windInfo info;
       
}
