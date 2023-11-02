public class Solution {
    public string Prefig(string[] pal) {
        for(int k=0; k<= pal.Length; k++){ 
            pal[k].ToLower();
        }
        string palfin ="";
         palfin += pal[0][0]; //para tener 1er primer igual 
        //i sirve para saber la palabra, el A es la posicion de la letra, la primera letra
        //aqui comeinza a
        int a=0;
        int j=0; //J sirve para saber
        while(a < pal[j].Length){ //pal j hace que sepamos la longitud y la comparamos con la palabra que estamos por comparar
            if(pal[0].Length <= palfin.Length && palfin.Length > 1){//hasta este punto, sabemos que la palabra no ha acabado
                return palfin; //si es menor ya no podria haber igualdad
            }else{ //aqui recorremos todas las palabras para obtener el valor
                for(int i=0; i<=pal[j].Length;i++){
                    if(palfin != pal[i][a].ToString()){
                        return "There is no common prefix among the input strings.";
                    }
                }
                if(a>0){ //si la a es mayor a 0 significa que almenos ya paso una vez por ahi
                    return palfin; //retornamos si ya paso una vez bn
                }
                a++; //pasamos a la siguiente letra que tenemos
                palfin += pal[0][a]; //si no hay comparacion con lo de la primera palabra, ya no nd
                //solo necesitamos la 1era palabra para asignar los valores al arreglo
            }   
        } 
        //cada que cambie de palabra J aumenta
    }
}