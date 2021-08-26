
/*  Lic. García Héctor
    Resolución recursiva de laberintos utilizando la técnica Backingtrack en C# 
*/

using System;

namespace MazeSolver
{
    class MazeSolver{
        /*  Defino el laberinto con los siguientes simbolos:
            S -> Punto de partida, # -> Obstáculo, . -> camino disponible,
            + -> camino a la salida, G -> salida del laberinto, X -> camino fallido
        */
        char[,] matrix = new char[,] {{'S','.','.','.','#','#'},{'#','.','#','.','.','.'},{'#','.','#','#','.','#'},{'.','.','#','.','#','#'},{'#','.','.','.','#','G'},{'#','.','#','.','.','.'}};
        int fil = 0;
        int col = 0;
        int x = 0;
        int y = 0;

        public char[,] getMatrix(){
            return this.matrix;
        }

        public void setMatrixSize(){
            this.fil = this.matrix.GetLength(0);
            this.col = this.matrix.GetLength(1);
        }

        /* Visualización del laberinto representado por la matriz */
        public void showMatrix(){
            for (int i = 0; i < this.fil; i++){   
                for (int j = 0; j < this.col; j++){
                    System.Console.Write(this.matrix[i,j] + " ");
                }
                System.Console.WriteLine("");
            }
        }

        /* Buscador de caminos recursivo */
        public Boolean FindPath(char[,] m, int x, int y){
            if(x<0 || x>=this.fil || y<0 || y>=this.col){
                return false;
            }
            if(m[x,y] == 'G'){
                return true;
            }
            if(m[x,y] == '#'){
                return false;
            }
            if(m[x,y] == '+'){
                return false;
            }
            
            //Agrego x,y como parte del camino
            m[x,y] = '+';

            //Norte    
            if(FindPath(m,x-1,y) == true){
                return true;
            }
            //Este
            if(FindPath(m,x,y+1) == true){
                return true;
            }
            //Sur
            if(FindPath(m,x+1,y) == true){
                return true;
            }
            //Oeste
            if(FindPath(m,x,y-1) == true){
                return true;
            }
            //Marco x,y como un camino no viable
            m[x,y] = 'x';
            return false;
        }

        static void Main(string[] args){
            MazeSolver maze = new MazeSolver();
            maze.setMatrixSize();
            maze.FindPath(maze.getMatrix(),0,0);
            maze.showMatrix();
        }
    }
}
