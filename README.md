# axxis-bacco
Bacco é um software para um bar. Foi nomeado a partir de Baco, um dos nomes de Dionísio, uma entidade mitológica grega que tem ligação com festas, vinhos e arte. É o primeiro software da Axxis Software

# o projeto

Utilizando uma stack de C#/ReactJS, o software tem o objetivo de rodar a operação de bares e restaurantes.

# backend

O backend modela o básico do funcionamento de um bar. Usuários, que são clientes, sentam-se às Mesas e lêem um QR Code na mesa que vai abrir uma nova comanda que vai conter o consumo do cliente. O cliente vai selecionar os Produtos que ele deseja através de uma interface visual, e ao confirmar, essas seleções irão gerar um Pedido anexado àquela Mesa. A aplicação deverá dividir os produtos que devem ser preparados na Cozinha (como pratos, porções e comestíveis em geral) ou no Balcão (como drinks, bebidas e produtos que já estejam prontos de uma maneira geral). Então, o Pedido é anexado à Mesa, constando como um pedido EM ABERTO. Quando o cliente for sair do bar, ele deverá fazer um Checkout, podendo ser acionado pelo proprio celular apontando para a Mesa na qual ele está consumindo, ou apresentando o numero da mesa para quem estiver no caixa. Quando o checkout for feito, todos os Pedidos feitos àquela Mesa serão registrados como Vendas no sistema, liberando o Cliente. O sistema então deverá ser capaz a partir deste fluxo, gerar relatórios diversos sobre Horários de Pico, Produtos mais Consumidos, Totalizadores de Venda por período, Clientes que mais consomem, e deverá ser capaz de fazer sugestões com base nestes dados - informando por exemplo que certo produto não tem saída e deverá ser revisto, ou que um determinado cliente é muito assíduo e podem ser oferecidas vantagens para ele, ou sugerir promoções. (Inserir também um sistema de cumprimentos ao Cliente, como desejando feliz aniversário, bom dia, boa tarde, boa noite etc etc). A autenticação deverá ser feita via OAuth, de forma que o Usuário possa logar no sistema usando Facebook/Instagram/Google e outras formas de identificação, registrando o cliente no processo. Também deverá ser capaz de administrar delivery.

O backend será disponibilizado em forma de API/Microserviços

# frontend

O frontend deverá ser desenhado de forma otimizada para mobile, de forma que o ciente deverá ser capaz de fazer tudo através do celular de forma autônoma, para que o sistema ofereça ao bar contratante uma maneira de automatizar o atendimento ao cliente, gerando reduções de custo e conforto para o cliente. O frontend deverá ser disponibilizado em forma de site e de aplicativo, possivelmente gerando benefícios para usuários que usem o aplicativo. O frontend terá alguns módulos:

- Módulo Ciente

Aqui, o usuário deverá ser capaz de olhar o cardápio, fazer pedidos, consultar seu histórico de pedidos, comunicar-se com o atendimento e fechar o próprio pedido através de pix/cartão de crédito/cartão de débito

- Módulo Balcão

Aqui, o usuário deverá conseguir administrar os pedidos que estão em aberto e visualizar quais entregas deverão ser feitas de produtos disponíveis no balcão (bebidas, drinks e quaisquer coisas já prontas)

- Módulo Cozinha

Aqui, o usuário deverá conseguir administrar os pedidos que estão em aberto e visualizar quais entregas deverão ser feitas de produtos que deverão ser preparados na cozinha (pratos, porções e etc)

- Módulo Recepção/Caixa

Este módulo deverá permitir o usuário a visualizar os pedidos que estão em abertos e fazer checkout dos mesmos, bem como completar cadastros de clientes caso haja a necessidade. Aqui também deverá ser possível fechar o movimento do dia e tirar relatórios básicos como o relatório do movimento do dia. Também deverá ser possível agendar/reservar mesas por este módulo.

- Módulo Administração

Este módulo terá acesso a todos os cadastros do sistema, permitindo ao administrador fazer cadastros dos mais variados, e tirar todos os relatórios possíveis para ter uma visão compreensiva do seu negócio e torná-lo cada vez mais rentável


