using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaGenerator : MonoBehaviour
{

    public class Cell{
        public bool visited = false;
        public bool[] status = new bool[3];
    }

    public Vector2 size;
    public int startPos = 0;
    public GameObject[] tiles;
    public Vector2 offset;

    List<Cell> board;

    // Start is called before the first frame update
    void Start()
    {
        MazeGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateArena(){
        int previousTile = Random.Range(0, tiles.Length);
        int randomTile;
        for (int i = 0; i < size.x; i++){
            for (int j = 0; j < size.y; j++){
                if (Random.Range(0,2) == 0)
                    randomTile = Random.Range(0, tiles.Length);
                else
                    randomTile = previousTile;
                var newTile = Instantiate(tiles[randomTile], new Vector3(i*offset.x,0,-j*offset.y), Quaternion.identity, transform);
                newTile.GetComponent<TileBehaviour>().UpdateTile(board[Mathf.FloorToInt(i+j*size.x)].status);
                newTile.name += " " + i + " " + j;

                previousTile = randomTile;
            }
        }
    }

    void MazeGenerator(){
        board = new List<Cell>();
        
        for (int i = 0; i < size.x; i++){
            for (int j = 0; j < size.y; j++){
                board.Add(new Cell());
            }
        }

        int currentCell = startPos;

        Stack<int> path = new Stack<int>();
        int k = 0;

        while(k < 1000){
            k++;

            board[currentCell].visited = true;

            List<int> neighbours = CheckNeighbours(currentCell);

            if (neighbours.Count == 0){
                if (path.Count == 0){
                    break;
                }
                else{
                    currentCell = path.Pop();
                }
            }
            else{
                path.Push(currentCell);

                int newCell = neighbours[Random.Range(0, neighbours.Count)];

                //if (newCell > currentCell){
                    int towerNumber = Random.Range(0, 3); 
                    board[currentCell].status[towerNumber] = true;
                    currentCell = newCell;
                    //if(Random.Range(0, 2) == 0)
                    //    board[newCell].status[towerNumber] = true;
                    //else
                    //    board[newCell].status[Random.Range(0, 3)] = true;   
                //} 
                
            }
        }
        GenerateArena();
    }

    List<int> CheckNeighbours(int cell){
        List<int> neighbours = new List<int>();

        //check up neighbour
        if(cell - size.x >= 0 && !board[Mathf.FloorToInt(cell - size.x)].visited){
            neighbours.Add(Mathf.FloorToInt(cell - size.x));
        }
        //check down neigbour
        if(cell + size.x < board.Count && !board[Mathf.FloorToInt(cell + size.x)].visited){
            neighbours.Add(Mathf.FloorToInt(cell + size.x));
        }
        //check right neigbour
        if((cell + 1) % size.x != 0 && !board[Mathf.FloorToInt(cell + 1)].visited){
            neighbours.Add(Mathf.FloorToInt(cell + 1));
        }
        //check legt neigbour
        if(cell % size.x != 0 && !board[Mathf.FloorToInt(cell - 1)].visited){
            neighbours.Add(Mathf.FloorToInt(cell - 1));
        }

        return neighbours;
    }
}
