# Controle de Medicamentos
Este sistema de gestão foi desenvolvido para controle de cadastros e movimentação de estoque, incluindo fornecedores, pacientes, funcionários e medicamentos. O objetivo é garantir organização, integridade dos dados e controle eficiente do estoque de medicamentos.

O sistema aplica regras de negócio para evitar duplicidade de registros, validar dados e manter o estoque sempre atualizado conforme entradas e saídas.

Desenvolvido por **Iago** e **Dayuã**  durante o curso Fullstack da [Academia do Programador](https://www.academiadoprogramador.net) 2026.

---

 FUNCIONALIDADES

 Módulo de Fornecedores  
- Cadastro de fornecedores  
- Visualização de fornecedores cadastrados  
- Edição de fornecedores  
- Exclusão de fornecedores  
- Validação de CNPJ único  

---

 Módulo de Pacientes  
- Cadastro de pacientes  
- Visualização de pacientes cadastrados  
- Edição de pacientes  
- Exclusão de pacientes  
- Validação de CPF e Cartão SUS  
- Validação de telefone em formatos específicos  
- Impedimento de duplicidade de Cartão SUS  

---

 Módulo de Medicamentos  
- Cadastro de medicamentos  
- Visualização de medicamentos  
- Edição de medicamentos  
- Exclusão de medicamentos  
- Controle de estoque automático  
- Destaque para medicamentos com menos de 20 unidades ("em falta")  
- Atualização de quantidade quando já existente  

---

 Módulo de Funcionários  
- Cadastro de funcionários  
- Visualização de funcionários  
- Edição de funcionários  
- Exclusão de funcionários  
- Validação de CPF único  

---

 Módulo de Estoque  

 Requisições de Entrada  
- Registro de entrada de medicamentos  
- Visualização de entradas  
- Atualização automática do estoque  
- Validação de quantidade e dados obrigatórios  

 Requisições de Saída  
- Registro de saída de medicamentos  
- Visualização de saídas  
- Controle de pacientes  
- Subtração automática do estoque  
- Bloqueio de saídas acima do estoque disponível  

---

COMO UTILIZAR O PROJETO

1. Clone o repositório ou baixe o projeto em .zip  
2. Abra o projeto na sua IDE (Visual Studio ou VS Code)  
3. Restaure as dependências (se aplicável)  
4. Execute o projeto  

     ```
     dotnet restore
     ```

4. Em seguida compile e execute o projeto com o comando: 

    ```
    dotnet run --project ControleMedicamentos.Console.App
    ```

## Requistitos

* .NET SDK 10.0