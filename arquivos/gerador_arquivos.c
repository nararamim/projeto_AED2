#include <stdio.h>
#include <stdlib.h>
#include <string.h>//necessário para strcat

int main(){
    
   FILE *arquivo;
   char nome[100][50] = {"Adelina Quadros","Adelino Barra","Almerinda Palmeira","Almor Caiado","Aludsio Sosa","Andreia Moita","Angelica Aranha","Angilica Galante","Anind Zarco","Anfnia Seixas","Antonio Viegas","Antonio Castelo","Armanda Amorim","Armindo Castalo","Artur Grillo","Augusta Paio","Basilio Pedroso","Branco Saraba","Camila Gabeira","Carminda Morais","Cassandra Varejo","Celeste Duarte","Clara Alcantara","Clarindo Areosa","Cleusa Goes","Daniel Vieyra","Danilo Olaio","Delfim Higuera","Delfina Garcia de Gondim","Delfina Perdigon","Domingos Pas","Dulce Froes","Edgar Carvalheiro","Elisa Themes","Emiliana Foquio","Emedlia Silvera","Emedlio Pimentel","Ermelinda Quintela","Esperada Cardoso","Estanislau Beserra","Eurico Siqueira","Feledcia Peassego","Filomena Barrios","Flamednia Leiria","Flor Portella","Fulvio Villegas","Gaudancio Fiees","Guaraci Damasceno","Guida Juca","Heleedsa Marins","Henrique Bento","Honorina Lira","Joaquim Rufino","Jorgina Bogalho","Judite Damasceno","Jussara Varanda","Jonatas Felgueiras","Letedcia Gago","Leonidas Mafra","Liana Cardim","Lina Andrade","Lurdes Cotrim","Manuel Capiperibe","Marilda Leio","Melinda Roserio","Micaela Chavez","Moaci Mendoa","Mercia Caeira","Neuza Francia","Neeamia Arruda","Nuno Balsemeo","Odete Vasques","Odilia Bello","Odilia Camello","Oliveira Carmona","Oliveira Senchez","Polibe Olivares","Quintiliano Sousa de Arronches","Quintino Alcantara","Rebeca Neto","Regina Barcellos","Rodolfo Paz","Romo Paranage","Sara Lameiras","Sidfnio Frois","Sofras Cuaresma","Silvio Mata","Spnia ou Sonia Guerreiro","Tabalipa Duarte","Tarrataca Soares","Telma Villalobos","Tibofarcio Camacho","Tibefarcio Colao","Trajano Fagundes","Taercio Mafra","Ubaldo Mainha","Urbano Rodrigues","Ximena Castilho","Zulmira Becerra","Zungela Ipiranga"};
   int conta[100];
   float saldo[100];
  
   float saldoRand;
   int  contaRand;
   
   for(int f=0; f<1000;f++){
       
    char arqNome[50] ={ "contas/"};
    sprintf(arqNome,"%s%d",arqNome,f);
    strcat(arqNome, ".txt");
   
    arquivo = fopen(arqNome,"w");
    for(int i=0; i<100; i++){
        contaRand = rand() % 1000000;
        conta[i] =contaRand;
        
        saldoRand = (float) rand() / 100000.0;
        saldo[i] =saldoRand;
        
       fprintf(arquivo, "%d-%s-%.2f\n",conta[i],nome[rand()%100],saldo[i]); 
    }
   }
    
    fclose(arquivo);
  
}