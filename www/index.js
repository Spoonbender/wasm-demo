import * as raffleLib from './wasm/raffle_core';
const {Raffle, Participant} = raffleLib;

function doRaffle() {
  const results = document.querySelector('#results');

  results.textContent = '';
  const winner = drawWinner();
  const msg = `The winner is... ${winner}!`;
  results.textContent = msg;
}

function drawWinner() {
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

  return raffle.draw_winner().display_name();
}

document.querySelector('#raffle').addEventListener('click', doRaffle);
