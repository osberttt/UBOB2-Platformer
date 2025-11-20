using System.Collections;
using System.Collections.Generic;
using UnityEngine; // namespace

public class Script1 : MonoBehaviour // class block
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() // function block
    {
        // array
        string[] fruitArray = new string[3];
        fruitArray[0] = "apple";
        fruitArray[1] = "banana";
        fruitArray[2] = "cherry";
        Debug.Log(fruitArray[5]);
        
        // list
        List<string> fruitList = new List<string>();
        fruitList.Add("apple");
        fruitList.Add("banana");
        fruitList.Add("cherry");
        fruitList.Add("apple");
        
        
        fruitList.Remove("banana");
        var listHasApple = fruitList.Contains("apple");
        Debug.Log(fruitList[1]);
   
        // queue
        Queue<int> people = new Queue<int>();
        people.Enqueue(1);
        people.Enqueue(2);
        people.Enqueue(4);
        people.Dequeue();
        
        // stack
        Stack<int> stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(4);
        stack.Pop();
        
        // hashset
        HashSet<string> fruitHashSet = new HashSet<string>();
        fruitHashSet.Add("apple");
        fruitHashSet.Add("banana");
        fruitHashSet.Add("cherry");
        fruitHashSet.Add("apple");
        var hashSetHasApple = fruitHashSet.Contains("apple");

    }

    // Update is called once per frame
    void Update() // function block
    {
        
    }
}
