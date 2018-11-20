#include <stdio.h>
#include <stdlib.h>
#include <string.h>//necessário para strcat
#include <math.h>

int main() {

	FILE *arquivo;
	char nome[200][50] = { "Adelina Quadros","Adelino Barra","Almerinda Palmeira","Almor Caiado","Aludsio Sosa","Andreia Moita","Angelica Aranha","Angilica Galante","Anind Zarco","Anfnia Seixas","Antonio Viegas","Antonio Castelo","Armanda Amorim","Armindo Castalo","Artur Grillo","Augusta Paio","Basilio Pedroso","Branco Saraba","Camila Gabeira","Carminda Morais","Cassandra Varejo","Celeste Duarte","Clara Alcantara","Clarindo Areosa","Cleusa Goes","Daniel Vieyra","Danilo Olaio","Delfim Higuera","Delfina Garcia de Gondim","Delfina Perdigon","Domingos Pas","Dulce Froes","Edgar Carvalheiro","Elisa Themes","Emiliana Foquio","Emedlia Silvera","Emedlio Pimentel","Ermelinda Quintela","Esperada Cardoso","Estanislau Beserra","Eurico Siqueira","Feledcia Peassego","Filomena Barrios","Flamednia Leiria","Flor Portella","Fulvio Villegas","Gaudancio Fiees","Guaraci Damasceno","Guida Juca","Heleedsa Marins","Henrique Bento","Honorina Lira","Joaquim Rufino","Jorgina Bogalho","Judite Damasceno","Jussara Varanda","Jonatas Felgueiras","Letedcia Gago","Leonidas Mafra","Liana Cardim","Lina Andrade","Lurdes Cotrim","Manuel Capiperibe","Marilda Leio","Melinda Roserio","Micaela Chavez","Moaci Mendoa","Mercia Caeira","Neuza Francia","Neeamia Arruda","Nuno Balsemeo","Odete Vasques","Odilia Bello","Odilia Camello","Oliveira Carmona","Oliveira Senchez","Polibe Olivares","Quintiliano Sousa de Arronches","Quintino Alcantara","Rebeca Neto","Regina Barcellos","Rodolfo Paz","Romo Paranage","Sara Lameiras","Sidfnio Frois","Sofras Cuaresma","Silvio Mata","Spnia ou Sonia Guerreiro","Tabalipa Duarte","Tarrataca Soares","Telma Villalobos","Tibofarcio Camacho","Tibefarcio Colao","Trajano Fagundes","Taercio Mafra","Ubaldo Mainha","Urbano Rodrigues","Ximena Castilho","Zulmira Becerra","Zungela Ipiranga","Adelina Quadros","Adelino Barra","Almerinda Palmeira","Almor Caiado","Aludsio Sosa","Andreia Moita","Angelica Aranha","Angilica Galante","Anind Zarco","Anfnia Seixas","Antonio Viegas","Antonio Castelo","Armanda Amorim","Armindo Castalo","Artur Grillo","Augusta Paio","Basilio Pedroso","Branco Saraba","Camila Gabeira","Carminda Morais","Cassandra Varejo","Celeste Duarte","Clara Alcantara","Clarindo Areosa","Cleusa Goes","Daniel Vieyra","Danilo Olaio","Delfim Higuera","Delfina Garcia de Gondim","Delfina Perdigon","Domingos Pas","Dulce Froes","Edgar Carvalheiro","Elisa Themes","Emiliana Foquio","Emedlia Silvera","Emedlio Pimentel","Ermelinda Quintela","Esperada Cardoso","Estanislau Beserra","Eurico Siqueira","Feledcia Peassego","Filomena Barrios","Flamednia Leiria","Flor Portella","Fulvio Villegas","Gaudancio Fiees","Guaraci Damasceno","Guida Juca","Heleedsa Marins","Henrique Bento","Honorina Lira","Joaquim Rufino","Jorgina Bogalho","Judite Damasceno","Jussara Varanda","Jonatas Felgueiras","Letedcia Gago","Leonidas Mafra","Liana Cardim","Lina Andrade","Lurdes Cotrim","Manuel Capiperibe","Marilda Leio","Melinda Roserio","Micaela Chavez","Moaci Mendoa","Mercia Caeira","Neuza Francia","Neeamia Arruda","Nuno Balsemeo","Odete Vasques","Odilia Bello","Odilia Camello","Oliveira Carmona","Oliveira Senchez","Polibe Olivares","Quintiliano Sousa de Arronches","Quintino Alcantara","Rebeca Neto","Regina Barcellos","Rodolfo Paz","Romo Paranage","Sara Lameiras","Sidfnio Frois","Sofras Cuaresma","Silvio Mata","Spnia ou Sonia Guerreiro","Tabalipa Duarte","Tarrataca Soares","Telma Villalobos","Tibofarcio Camacho","Tibefarcio Colao","Trajano Fagundes","Taercio Mafra","Ubaldo Mainha","Urbano Rodrigues","Ximena Castilho","Zulmira Becerra","Zungela Ipiranga" };
	int conta[1000];
	float saldo[1000];
	int agencias[100] = { 240 ,301 ,479,384, 356 ,123 ,405 ,270 ,481,371,180,328,97,247,490,301,180,38,310,443,294,241,212,415,306,413,451,117,407,24 ,46 ,148 ,177 ,25 ,384 ,33 ,148 ,142 ,156 ,481 ,13 ,336,309 ,462 ,436 ,151 ,264 ,116 ,190 ,74 ,411 ,336 ,167 ,123 ,104 ,473 ,388 ,407 ,90 ,296 ,431 ,488 ,296 ,109,365,32 ,494 ,13 ,174 ,150 ,346 ,187 ,339 ,155 ,150 ,275 ,307 ,266 ,243 ,349 ,340 ,154 ,37 ,359 ,130 ,141 ,332 ,18 ,48 ,275 ,166 ,332 ,263 ,462 ,293 ,129 ,347 ,287 ,494,21 };


	float saldoRand;
	int  contaRand;

	for (int f = 0; f < 100; f++) {

		int aux = (int)(2 * agencias[f] / 0.00032) + 1;

		char arqNome[50] = { "contas/" };
		sprintf(arqNome, "%s%d", arqNome, aux);
		strcat(arqNome, ".txt");

		arquivo = fopen(arqNome, "w");
		for (int i = 0; i < 1000; i++) {
			contaRand = rand() % 1000000;
			conta[i] = contaRand;

			saldoRand = (float)rand() / 100000.0;
			saldo[i] = saldoRand;

			fprintf(arquivo, "%d-%s-%.2f\n", conta[i], nome[rand() % 200], saldo[i]);
		}
	}

	fclose(arquivo);

}