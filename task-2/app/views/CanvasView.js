import { connect } from 'react-redux';
import Canvas from '../components/Canvas';
import { addEllipse } from '../data/modules/canvas';

const mapStateToProps = connect(
	state => ({
		figures: state.canvas.figures
	}),
	dispatch => ({
		drawEllipse: (points, color) => dispatch(addEllipse(points, color))
	})
);

export default mapStateToProps(Canvas);
