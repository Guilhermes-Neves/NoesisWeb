#language: pt

Funcionalidade: Buscar médicos
    Para que eu possa marcar consultas médicas
    Sendo um paciente que necessite de atendimento
    Posso realizar buscas no site

    Cenário: Buscar médicos por especialidade e cidade
        Dado que visito a página do Guia médico
        Quando efetuo a busca com os dados "<especialidade>" "<estado>" "<cidade>"  "<tipoEstabelecimento>"
        Então eu so vejo médicos da "<especialidade>" e "<abreviacao>"

     Exemplos: 
     | especialidade | estado         | cidade         |abreviacao | tipoEstabelecimento |
     | Cardiologia   | Rio de Janeiro | Rio de Janeiro |RJ         | medico              |

     Cenário: Validar ausência da cidade de São Paulo
        Dado que visito a página do Guia médico
        Quando efetuo a busca com os dados "<especialidade>" "<estado>" "<cidade>"  "<tipoEstabelecimento>"
        Então eu não vejo a cidade de "SP" presente

     Exemplos: 
     | especialidade | estado         | cidade         |abreviacao | tipoEstabelecimento |
     | Cardiologia   | Rio de Janeiro | Rio de Janeiro |RJ         | medico              |
