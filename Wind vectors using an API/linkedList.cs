using System.Collections;
using System.Collections.Generic;
using UnityEngine;

unsafe public class linkedList : MonoBehaviour
{
    public linkedList()
    {
        head = null;
    }



    //add wind info data to the linked list
    public void add_windData(windInfo a_info)
    {
        add_windData(head, a_info);
    }

    private void add_windData(node head, windInfo a_info)
    {
        //in this case, there is no wind data in the list.. YET
        if (head == null)
        {
            head = new node(a_info);

        } else
        {
            node temp = new node(a_info);
            temp.connect_next(head);
            head = temp;
        }
    }


    public void display_info()
    {
        if (head != null)
        {
            display_info(head);
        }
        else
            print("list is empty");
    }
    
    //this class linkedList HAS A object of the node class, called head. We will use head to call
    //node's display function and recurse it. 
    private void display_info(node head)
    {
        if (head != null)
        {
            head.display();
            display_info(head.go_next());
        }
    }


    //the linked list is managed by a head pointer
    private node head;

}
