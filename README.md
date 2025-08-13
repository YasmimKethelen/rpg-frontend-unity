# RPG Frontend Unity

Este repositório contém o frontend do nosso RPG 2D, desenvolvido em Unity.
Está configurado para rodar no navegador (WebGL).

Este README ensina passo a passo desde instalar Unity até colaborar via GitHub.

# 📂 Estrutura do Projeto

rpg-frontend-unity/
│
├─ Assets/            # Scripts, sprites, cenas (SUBIR)
├─ Packages/          # Lista de pacotes (SUBIR)
├─ ProjectSettings/   # Configs do projeto (SUBIR)
├─ Library/           # Cache Unity (NÃO SUBIR)
├─ Temp/              # Temporários (NÃO SUBIR)
├─ Logs/              # Logs (NÃO SUBIR)
├─ Builds/            # Builds do jogo (NÃO SUBIR)
└─ .gitignore         # Ignora arquivos desnecessários



# ⚙️ Pré-requisitos
Git → https://git-scm.com/downloads

Git LFS → https://git-lfs.github.com/

Unity Hub → https://unity.com/download

Unity Editor LTS

Template: 2D Built-in Render Pipeline

Suporte WebGL marcado

Versão exata em ProjectSettings/ProjectVersion.txt

# 📝 Clonando o Projeto

▶️ git clone https://github.com/seuusuario/rpg-frontend-unity.git
▶️ cd rpg-frontend-unity
▶️ git lfs install

🔧 Abrindo no Unity

# 1️⃣ Abra o Unity Hub:


# 2️⃣ Adicione o projeto:

Clique em Add

Selecione a pasta raiz do projeto (rpg-frontend-unity)

# 3️⃣ Abra o projeto:

Clique no projeto adicionado no Hub

⚠️ Não abra apenas a pasta Assets, sempre a raiz do projeto.

# Instalar o Rider (se ainda não tiver)
Baixe o Rider: https://www.jetbrains.com/rider/download/

Instale normalmente no Windows.

Se você tiver a licença, ative; existe versão de teste de 30 dias.

# Configurar o Unity para usar o Rider

Abra o Unity Editor.

Vá em Edit → Preferences → External Tools.

Em External Script Editor, clique e selecione Rider.

Se Rider não aparecer na lista, escolha Browse… e selecione o executável do Rider (Rider64.exe).

Marque as opções:

Generate all .csproj files → garante que todos os scripts Unity apareçam no Rider

Editor Attaching → habilita depuração pelo Rider

# Abrir o projeto no Rider

Abra o Rider.

Clique em Open e selecione a pasta raiz do projeto Unity (rpg-frontend-unity).

O Rider vai ler os arquivos .csproj e carregar todos os scripts.

Não abra só Assets, abra sempre a raiz do projeto.

# Configurar o debugger

No Unity, vá em Edit → Preferences → External Tools → Editor Attaching → deve estar habilitado.

No Rider, instale o plugin Unity Support (geralmente já vem incluído).

Agora você consegue clicar em Attach to Unity Editor no Rider e depurar scripts C# enquanto o jogo roda no Editor.

Opcional: desinstalar VS Code como editor externo
No Unity, ainda em Preferences → External Tools, apenas selecione Rider como editor externo.

Git/GitHub continua funcionando normalmente no terminal do Rider ou no terminal externo.

# 🌐 Testando no Navegador (WebGL)
Vá em File → Build Settings…

Selecione WebGL e clique em Switch Platform

Após dar Switch Platform, e aparecer as opçoes de Build e Build and Run

Clique em Build and Run

⚠️Se o botão de build estiver inativo reinicie o unity editor!!!

Vai abrir uma janela para selecionar a pasta

Crie uma pasta nova para a build, por exemplo:

swift
Copiar
Editar
rpg-frontend-unity/Builds/WebGL/
Selecione essa pasta e clique Select Folder

O Unity vai gerar dentro dela todos os arquivos WebGL:

index.html → página principal do jogo

Build/ → arquivos do jogo em WebGL

TemplateData/ → arquivos de template

Quando terminar, o Unity abre automaticamente uma aba no navegador com o jogo rodando

💡 Dicas importantes:

Sempre crie uma pasta separada para cada build, assim você não sobrescreve builds anteriores.

O Unity WebGL não permite gerar dentro da pasta Assets ou ProjectSettings; precisa ser fora das pastas do projeto.

Depois, você pode versionar apenas o código e assets, não o build gerado, pois ele pode ser muito grande.

Clique em Build and Run → O jogo abre no navegador local

# 🔄 Versionamento Git

Puxe alterações antes de começar:

▶️ git pull origin main

Trabalhe em branches próprias:

▶️ git checkout -b minha-feature

Commit e push:

▶️ git add .
▶️ git commit -m "Descrição do que foi feito"
▶️ git push origin minha-feature

# Atualize o main via Pull Request no GitHub.

# ⚠️ Não versionar: Library/, Temp/, Logs/, Builds/
