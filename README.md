# LP1-Projecto3
# Projeto 3 de Linguagens de Programação I 2019/2020

##  Roguelike

### Autoria - Grupo 10

- António Branco (a21906811)
  
  Criou o repositório e fez o método `Main` ler os argumentos de inicialização. Inicializou o método `Menu` com as opções e o tratamento de input. Criou a classe dos `PowerUp` e com que no menu o programa pause até o jogador pressionar Enter após a escolha das opções 2 a 4. Criou as listas `HighScoreList` e `SaveGameList`, fez os métodos que tratam dos saves e dos scores. Fez a Documentação XML e parte da comentação, fez a estrutura do relatório.

- João Gonçalves (a21901696)
  
  Inicializou o método `Game` e criou o método `Map` onde desenha o mapa com os devidos gráficos. Fez o movimento do jogador e as restrições impostas a este pelos obstáculos. Completou o método `PowerUp` fazendo a interação com o jogador e a adição de pontos hp. Fez a interface do usuário e implementou as mensagens de ação do jogador e inimigos. Completou as opções do `Menu`.

- Vasco Duarte (a21905658)
  
  Inicializou as classes `Map`, `Enemies`, `PoweUps`, `Ending` e `Player`. Completou o método `Main` e fez a geração procedimental. Completou o método `Game` com as condições de derrota. Fez o avanço de nivel e elaborou o teleporte no movimento do jogador e limitou o movimento do jogador ao mapa. Fez os inimigos, com as suas ações individuais(com que os inimigos andassem, tirassem hp e não interagissem com os power ups). Fez as teclas intantanêas no movimento do jogador. Comentou o código.

 ## [Repositório git](https://github.com/panpan58/LP1-Projecto3)

## Arquitetura da Solução
O programa é inicializado através do ficheiro "Program.cs" que começa por esperar que o utilizador introduza os parâmetros necessários para que o jogo seja lançado. Após adequirir esses pârametros que correspondem as dimenções do mapa, é chamada a função `Menu` onde o jogador vai poder ver as regras, os autores, os highscores, sair do programa e iniciar o jogo. Ao iniciar o jogo é criado o mapa através da classe `Map`, é desenhado o mapa a partir do método `Mapdraw` que vai usar variaveis das classes `Player`, `Enemy`, `PowerUp` e `Ending`. A classe `Player` é responsavél pela criação do player e do seu `HP` conforme as dimensões do mapa e por atualizar a posição do player no mapa respeitando as restrições e atualizar os seus pontos de vida de acordo com as respetivas restrições. A classe `Enemy` é responsavél por criar os diferentes inimigos e atualizar as posições de todos os inimigos existentes no mapa de acordo com as devidas restrições. Consoante a `luck` pode criar dois tipos diferentes de inimigos. A classe `PowerUp` é responsável pela criação dos power ups e consoante a `luck` pode criar três tipos diferentes de power ups. A classe `Ending` é responsável por gerar a posição do fim do nivel. Depois da criação e da colocação de cada objeto no mapa o jogador pode se mover ou teletransportar no jogo, ele pode fazer duas ações no seu turno, enquanto os seus inimigos apenas podem fazer uma. As ações do jogador fazem perder vida dependendo da ação e se ele vai a 0 ou menos perde o jogo. Se o jogador chega ao fim do nivel passa para o seguinte nivel com a opção de fazer save da sua partida. Também é de notar que o mapa mostra através da interface as várias ações e estatisticas do jogo. Os inimigos no seu turno tentam sempre se apóximar do jogador, se eles estão ao pé do jogador no seu turno baixa o `hp` do jogador. Quando o jogador morre o seu score é igual ao nivel que chegou, se este estiver entre os top10 vai ficar guardado no HighScore com o seu nome. No inicio do jogo o jogador tem a opção de fazer load de uma partida anterior.

## Diagrama UML 
![](https://cdn.discordapp.com/attachments/635779092373045248/721118207674417152/Diagrama_UML.png)
|Autor|Referência|
| - | - |
|Vasco Duarte| https://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-int-number
|João Gonçalves|https://stackoverflow.com/questions/3414900/how-to-get-a-char-from-an-ascii-character-code-in-c-sharp
|João Gonçalves| https://stackoverflow.com/questions/11550879/detecting-key-presses-in-console
|João Gonçalves|https://unicode-table.com/pt/#basic-latin
|António Branco|https://www.google.com/search?q=how+to+use+console.readkey+in+input&oq=how+to+use+console.readkey+in+input&aqs=chrome..69i57.8223j0j7&sourceid=chrome&ie=UTF-8
|João Gonçalvez|https://docs.microsoft.com/en-us/dotnet/api/system.console.readkey?view=netcore-3.1
|António Branco|https://docs.microsoft.com/en-us/dotnet/api/system.io.directory?view=netcore-3.1
|António Branco|http://zetcode.com/csharp/writetext/#:~:text=C%23%20write%20text%20file%20with%20File.&text=The%20File.,already%20exists%2C%20it%20is%20overwritten.&text=The%20example%20writes%20text%20to%20a%20file
