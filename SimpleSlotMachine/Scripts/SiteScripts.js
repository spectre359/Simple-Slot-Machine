function isNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode != 46 && (charCode < 48 || charCode > 57)))
        return false;
    return true;
}

function createSlotMachines(num) {
    
    var elements = [];
    var machines = [];
    for (var i = 1; i <= num; i++) {
        elements[i] = document.querySelector('#machine' + i); //find the divs with pictures
    }
    for (var m = 1; m < elements.length; m++) {
        const machine = new SlotMachine(elements[m], { //for each div create a machine and spin it
            active: 0, delay: 500, randomize() {
                return 0;
            }
        });
        machine.shuffle(9999);
    }

}