PROJETO URNA ELETRÔNICA

##SOBRE O PROJETO:
Este é um sistema de votação eletrônica desenvolvido para teste para empresa DeMaria! que permite:

Visualizar candidatos digitando seus números
Confirmar votos com segurança
Armazenar os resultados de forma protegida

##COMO EXECUTAR O SISTEMA:

Pré-requisitos:
Tenha o .NET 8.0 instalado
Baixe todos os arquivos do projeto

**Passo a passo:

Abra o terminal/prompt de comando
Navegue até a pasta do projeto
Execute o comando:

>dotnet run
Aguarde a janela da urna aparecer

COMO VOTAR:

Na janela que abrir:

Digite o número do candidato
Veja a foto e informações do candidato
Clique em "CONFIRMAR" para registrar seu voto
Você receberá uma mensagem de confirmação

##ARMAZENAMENTO DOS DADOS:

**Localização:

Todos os dados são salvos na pasta "Data" dentro do projeto
Arquivos gerados:

"votos.txt": Registro de todos os votos

Formato: Número|Data|CódigoSegurança|CódigoAnterior

Pasta "Fotos": Armazena as imagens dos candidatos

**Segurança:

Cada voto gera um código único
Os votos são vinculados entre si
Qualquer alteração é facilmente detectada



##ESTRUTURA BÁSICA:

Models/: Define candidatos e votos
Services/: Lógica de votação e segurança
FormUrna.cs: Interface do usuário
Program.cs: Inicialização do sistema

##OBSERVAÇÕES FINAIS:

*Para reiniciar a votação, basta apagar o arquivo votos.txt

*As fotos devem estar no formato correto para serem exibidas