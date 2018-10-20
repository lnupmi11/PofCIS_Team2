export const INCREMENT_COUNTER = 'INCREMENT_COUNTER';
export const DECREMENT_COUNTER = 'DECREMENT_COUNTER';

const increment = () => ({
	type: INCREMENT_COUNTER
});

function decrement() {
	return {
		type: DECREMENT_COUNTER
	};
}

function incrementIfOdd() {
	return (dispatch, getState) => {
		const { counter } = getState();

		if (counter % 2 === 0) {
			return;
		}

		dispatch(increment());
	};
}

function incrementAsync(delay: number = 1000) {
	return dispatch => {
		setTimeout(() => {
			dispatch(increment());
		}, delay);
	};
}

export { increment, decrement, incrementIfOdd, incrementAsync };
