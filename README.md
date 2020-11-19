Descrição:
----------

Projeto criado com **Visual Studio Community 2015**

A aplicação possui um banco de dados interno **CadastroCliente.mdf**, que foi criado com **SQL Server 2014 Express** e utiliza **LocalDB** para se conectar.

Instalação
----------

Como o projeto usa um arquivo de banco de dados local, o caminho do arquivo vai depender do local que for clonado ou baixado o .zip

A imagem abaixo, mostra a janela **Soluction Explorer** com a estrutura do projeto com o arquivo do banco de dados **CadastroCliente.mdf**:

![Soluction Explorer](https://github.com/adevecchi/cadastro-clientes-winforms/blob/main/screenshot/img4.png)

Selecionar o arquivo de banco de dados **CadastroCliente.mdf** e na janela **Properties** no campo **Full Path** vai estar o caminho completo do banco de dados.

Na janela **Properties** no campo **Full Path** selecionar e copiar seu conteúdo, para adicionar na string de conexão, conforme mostrado abaixo:

```xml
<connectionStrings>
    <add name="BancoDeDados" connectionString="Server=(LocalDB)\MSSQLLocalDB; Integrated Security=true; AttachDbFileName=<Conteudo_do_campo_Full_Path>"/>
</connectionStrings>
```

Esse trecho de código esta no arquivo **App.config** e deve ser substituido o **<Conteudo_do_campo_Full_Path>** pelo valor de **Full Path** na janela **Properties**, conforme mostra imagem abaixo:

![Properties](https://github.com/adevecchi/cadastro-clientes-winforms/blob/main/screenshot/img5.png)

A imagem abaixo mostra alguns registros que já estão no banco de dados para teste:

![Registros do banco de dados](https://github.com/adevecchi/cadastro-clientes-winforms/blob/main/screenshot/img3.png)

Captura de tela
---------------

![Imagem App](https://github.com/adevecchi/cadastro-clientes-winforms/blob/main/screenshot/img1.png)

![Imagem App](https://github.com/adevecchi/cadastro-clientes-winforms/blob/main/screenshot/img2.png)
