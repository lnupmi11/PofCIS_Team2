import * as React from 'react';
import withStyles from '@material-ui/core/styles/withStyles';
import PropTypes from 'prop-types';
import Menu from '../components/Menu';
import CanvasView from './CanvasView';

const styles = () => ({
  app: {
    display: 'flex',
    height: '100%'
  }
});

class App extends React.Component {
  static propTypes = {
    classes: PropTypes.shape({
      app: PropTypes.string.isRequired
    }).isRequired
  };

  render() {
    const { classes } = this.props;
    return (
      <div className={classes.app}>
        <Menu />
        <CanvasView />
      </div>
    );
  }
}

export default withStyles(styles)(App);
