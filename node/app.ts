import * as raffleLib from './wasm/raffle_core';
const {Raffle, Participant} = raffleLib;

const raffle = new Raffle();

raffle.add_participant(new Participant('Magnus', 'Mårtensson'));
raffle.add_participant(new Participant('Alon', 'Fliess'));
raffle.add_participant(new Participant('Eran', 'Stiller'));
raffle.add_participant(new Participant('Amir', 'Zuker'));
raffle.add_participant(new Participant('Vitali', 'Zaidman'));
raffle.add_participant(new Participant('Erez', 'Pedro'));
raffle.add_participant(new Participant('Alex', 'Pshul'));
raffle.add_participant(new Participant('Moaid', 'Hathot'));
raffle.add_participant(new Participant('Ronen', 'Levinson'));
raffle.add_participant(new Participant('Nir', 'Dobovizki'));
raffle.add_participant(new Participant('Eyal', 'Ellenbogen'));
raffle.add_participant(new Participant('Michael', 'Donkhin'));
raffle.add_participant(new Participant('Vered', 'Flis'));

console.log('Drawing a winner...');
console.log(raffle.draw_winner().display_name());
