// MODAL ID - ELE CRIA UM ID PARA OS ELEMENTOS DO CARD
function modalID() {
    let id = 1;
    const produtos = document.querySelectorAll(".produtos-card");
    produtos.forEach((produto) => {
        produto.setAttribute("id", id);
        for (i = 0; i < produto.children.length; i++) {
            produto.children[i].setAttribute("id", id);
        }

        id++;
    });
}

$(document).ready(function () {
    $("#cpf").mask("999.999.999-99");
});

// FUNÇÃO QUE ABRE O MODAL
function abrirModal() {
    $(".modal-content").hide();
    const btnMais = document.querySelectorAll(".ver-mais");

    btnMais.forEach((btn) => {
        btn.addEventListener("click", () => {
            $(".modal-content").fadeIn();
            $("body").css({ overflow: "hidden" });
        });
    });
}

// FUNÇÃO QUE FECHA O MODAL
function fecharModal() {
    $(".sair").click(function () {
        $(".modal-content").fadeOut();
    });

    window.addEventListener("click", (e) => {
        const el = e.target;
        if (el.classList.contains("modal-content")) {
            $(".modal-content").fadeOut();
        }
    });
}

// CALCULAR PREÇO
function calcularPreco() {
    // SELETORES DO JS
    const input = document.querySelector("#qtd");
    const preco = document.querySelector("#preco");
    const estoque = document.querySelector("#disp");

    let estoqueDB = Number(document.querySelector(".quantidadeDB").innerHTML) - 1; // Quantidade do Banco - 1
    let valorDB = Number(document.querySelector(".precoDB").innerHTML); // Valor do Banco de Dados FICA AQUI

    

    let i = 1; // Contador
    let total; // Vai ficar atualizando preço

    // INICIALMENTE, O VALOR DO INPUT VALUE VAI COMEÇAR POR 1. ESTE TAMBÉM É O MOTIVO POR SUBTRAIR 1 DO ESTOQUE
    input.value = i;
    estoque.innerHTML = estoqueDB;

    // FORMATANDO O VALOR PARA REAL
    preco.innerHTML = formatarReal(valorDB);

    // QUANDO EU CLICAR EM "+", VAI SER ADICIONADO UM ITEM AO CARRINHO
    const mais = document.querySelector(".mais");
    mais.addEventListener("click", () => {
        input.value = i += 1;
        estoque.innerHTML = estoqueDB -= 1;

        total = input.value * valorDB;
        preco.innerHTML = formatarReal(total);
    });

    if (Number(document.querySelector(".quantidadeDB").innerHTML) === 0) {
        mais.disabled = true 
    }

    // QUANDO EU CLICAR EM "-", VAI SER REMOVIDO UM ITEM DO CARRINHO
    const menos = document.querySelector(".menos");
    menos.addEventListener("click", () => {
        input.value = i -= 1;
        estoque.innerHTML = estoqueDB += 1;

        if (i === 1) {
            menos.disabled = true;
        }

        total = input.value * valorDB;
        preco.innerHTML = formatarReal(total);
    });

    input.addEventListener("input", () => {
        total = input.value * valorDB;
        preco.innerHTML = formatarReal(total);
        i = Number(input.value);
        estoque.innerHTML = estoqueDB - Number(input.value);
    });

    // AO CLICAR NO CARRINHO, CONFIRMA A ADIÇÃO
    const car = document.querySelector(".car");
    const nomeProduto = document.querySelector(".nomeProduto");

    car.addEventListener("click", () => {
        alert("Produto adicionado ao carrinho");
        $(".modal-content").fadeOut();
        window.location.reload(true)

  

   
    });


    console.log(estoqueDB)
}

// FORMATA O VALOR PARA REAL
function formatarReal(total) {
    return total.toLocaleString("pt-br", {
        style: "currency",
        currency: "BRL",
    });
}

modalID();
calcularPreco();
fecharModal();
abrirModal();

// ELE NÃO LIMPA OS VALORES AO FECHAR

