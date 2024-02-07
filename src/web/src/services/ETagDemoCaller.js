import axios from "axios";
import config from "../config"

const baseURL = config.api.baseUrl;
const frontendVersionETag = '1.0.0'; // The current frontend version ETag

// Create an Axios instance with default headers, including the ETag
const ETagDemoCaller = axios.create({
  baseURL,
  headers: {
    "Content-Type": "application/json",
    "If-None-Match": frontendVersionETag, // Include the ETag header here
  },
});

// Response interceptor to handle version mismatches
ETagDemoCaller.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    // Check if the error is due to a version mismatch
    if (error.response && error.response.status === 409) {
      // Notify the user about the version mismatch and suggest refreshing the page
      window.alert(
        "A new version of the application is available. Please refresh the page."
      );
        // Further error handling or rejection
        // eslint-disable-next-line no-restricted-globals
        window.location.reload();
    }
    return Promise.reject(error);
  }
);

export default ETagDemoCaller;